using HR.LMS.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace HR.LMS.Application
{
    public static class ApplicationServicesRegis
    {
        public static IServiceCollection ConfigApplicationServices(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(MappingProfile)); -- CONS: Repeat code at every per profile
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Tranverse every mapping PROFILE that inheritance (EX: MappingProfile : Profile )
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
