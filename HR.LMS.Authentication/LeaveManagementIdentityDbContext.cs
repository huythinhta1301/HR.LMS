using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Authentication
{
    public class LeaveManagementIdentityDbContext : DbContext
    {

        public LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext> otp) : base(otp)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementIdentityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
