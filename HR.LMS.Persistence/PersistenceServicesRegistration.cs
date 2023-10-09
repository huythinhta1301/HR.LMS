using HR.LMS.Application.Contracts.Identity;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Authentication.Services;
using HR.LMS.Persistence.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LMS.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection PersistenceConfigServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<LeaveManagementDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("LMS_SV1_URL"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();


            return services;
        }
    }
}
