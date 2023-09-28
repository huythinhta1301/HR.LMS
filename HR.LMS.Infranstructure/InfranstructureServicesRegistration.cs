using HR.LMS.Application.Contracts.Infranstructure;
using HR.LMS.Application.Models;
using HR.LMS.Infranstructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Infranstructure
{
    public static class InfranstructureServicesRegistration
    {
        public static IServiceCollection ConfigInfra (this IServiceCollection services, IConfiguration config)
        {

            services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
