using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using core7_msyql_angular14.Entities;
using core7_msyql_angular14.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace core7_msyql_angular14.Services
{    
    public interface IAuthService {
        User SignupUser(User userdata, string passwd);
        User SignUser(string usrname, string pwd);
        UserRole Roles(int userid);
    }

    public class AuthService : IAuthService
    {
        private DataDbContext _context;
        private readonly AppSettings _appSettings;

         IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

        public AuthService(
            DataDbContext context,
            IOptions<AppSettings> appSettings
            )
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public User SignupUser(User userdata, string passwd)
        {
            
            User xusermail = _context.Users.Where(c => c.Email == userdata.Email).FirstOrDefault();
            if (xusermail != null) {
                throw new AppException("Email Address was already taken...");
            }

            User xusername = _context.Users.Where(c => c.UserName == userdata.UserName).FirstOrDefault();
            if (xusername != null) {
                throw new AppException("Username was already taken...");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var xkey = config["AppSettings:Secret"];
            var key = Encoding.ASCII.GetBytes(xkey);

            // CREATE SECRET KEY FOR USER TOKEN===============
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userdata.Email)
                }),
                // Expires = DateTime.UtcNow.AddDays(7),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var secret = tokenHandler.CreateToken(tokenDescriptor);
            var secretkey = tokenHandler.WriteToken(secret);

            userdata.Secretkey = secretkey.ToUpper();             
            userdata.Password = BCrypt.Net.BCrypt.HashPassword(passwd);
            userdata.Profilepic = "/resources/users/pix.png";
            userdata.Isactivated = 0;
            userdata.Isblocked = 0;
            userdata.Mailtoken = 0;
            _context.Users.Add(userdata);                     
            _context.SaveChanges();

            // ADD USER ROLES
            int newId = userdata.Id;
            UserRole userRole = new UserRole();
            userRole.UserId = newId;
            userRole.RoleName="USER";
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();

            return userdata;
        }

        public User SignUser(string usrname, string pwd)
        {
           try {
                    User xuser = _context.Users.Where(c => c.UserName == usrname).FirstOrDefault();
                    if (xuser != null) {
                        if (!BCrypt.Net.BCrypt.Verify(pwd, xuser.Password)) {
                            throw new AppException("Incorrect Password...");
                        }
                        if (xuser.Isactivated == 0) {
                            throw new AppException("Please activate your account, check your email inbox.");
                        }
                        return xuser;
                    } else {
                        throw new AppException("Username not found, please register first...");
                    }
            } catch(AppException ex) {
                    throw new AppException(ex.Message);
            }            
        }

        public UserRole Roles(int userid)
        {
            UserRole xroles = _context.UserRoles.Where(c => c.UserId == userid).FirstOrDefault();
            return xroles;
            // throw new NotImplementedException();
        }
    }
}