using Microsoft.EntityFrameworkCore;
using core7_msyql_angular14.Entities;
// using Microsoft.Extensions.Configuration;

namespace core7_msyql_angular14.Helpers
{

   public class DataDbContext : DbContext
    {

        // public DataDbContext(DbContextOptions<DataDbContext> options): base(options){
        // }        

        protected readonly IConfiguration Configuration;

        public DataDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            options.UseMySql(Configuration.GetConnectionString("Default"), serverVersion);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRole> UserRoles {get; set;}

    }

}