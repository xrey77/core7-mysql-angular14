using Microsoft.EntityFrameworkCore;
using core7_msyql_angular14.Entities;

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
            var connectionString = "server=127.0.0.1;user=rey;password=rey;database=core7-angular14";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            options.UseMySql(connectionString, serverVersion);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}