using HR.LMS.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Application.Contracts.Infranstructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
