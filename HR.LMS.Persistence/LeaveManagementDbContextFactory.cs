using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.LMS.Persistence
{
    public class LeaveManagementDbContextFactory
    {
        private readonly IConfiguration _configuration;
        public LeaveManagementDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public LeaveManagementDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            var connectionString = _configuration.GetConnectionString("LMS_SV1_URL");

            builder.UseSqlServer(connectionString);

            return new LeaveManagementDbContext(builder.Options);
        }
    }
}
