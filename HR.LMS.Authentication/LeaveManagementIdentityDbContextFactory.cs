using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Authentication
{
    internal class LeaveManagementIdentityDbContextFactory
    {
        private readonly IConfiguration _configuration;
        public LeaveManagementIdentityDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LeaveManagementIdentityDbContext CreateIdentityDbContext()
        {
            var builder = new DbContextOptionsBuilder<LeaveManagementIdentityDbContext>();
            var connectionString = _configuration.GetConnectionString("LMS_SV1_URL");

            builder.UseSqlServer(connectionString);

            return new LeaveManagementIdentityDbContext(builder.Options);
        }
    }
}
