using HR.LMS.Application.Contracts.Infranstructure;
using HR.LMS.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HR.LMS.Infranstructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _setting { get; }
        public EmailSender(IOptions<EmailSettings> setting)
        {
            _setting = setting.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_setting.Key);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _setting.FromAddress,
                Name = _setting.FromName
            };
            var msg = MailHelper.CreateSingleEmail(from, to,email.Title,email.Content, email.Content);
            var resp = await client.SendEmailAsync(msg);

            return resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
