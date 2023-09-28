using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.LMS.Persistence
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = configuration.GetConnectionString("LMS_SV1_URL");

            builder.UseSqlServer(connectionString);

            return new LeaveManagementDbContext(builder.Options);
        }
    }
}
