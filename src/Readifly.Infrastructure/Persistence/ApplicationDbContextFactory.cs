using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Readifly.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            // Configuración para desarrollo
            var connectionString = "Server=bqljebmd1qbgpncyr3kd-mysql.services.clever-cloud.com;Port=3306;Database=bqljebmd1qbgpncyr3kd;Uid=uymof1nkbx5nzt45;Pwd=OgzR3sLQQwIhMBsPGwiz;SslMode=Required;";
            
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
