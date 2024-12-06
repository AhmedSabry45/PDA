

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PDA.Models;
using System.Net;
using System.Net.Mail;

 
namespace PDA.Interceptor
    {
    public class MailService : IMailService
    {
        private readonly IOptions<MailSettings> _mailSettings;
        private readonly IConfiguration _configuration;

        public MailService(IOptions<MailSettings> mailSettings, IConfiguration configuration)
        {
            _mailSettings = mailSettings;
            _configuration = configuration;
        }

        

        public Task SendMailAsync(IEnumerable<string> emails, string subject, string message)
        {
            // Retrieve SMTP settings from appsettings.json
            var smtpEmail = _configuration["SmtpSettings:Email"];
            var smtpPassword = _configuration["SmtpSettings:Password"];
            var smtpHost = _configuration["SmtpSettings:Host"];
            var smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
            //var enableSsl = bool.Parse(_configuration["SmtpSettings:EnableSsl"]);

            var client = new SmtpClient(smtpHost, smtpPort)
            {
                //EnableSsl = enableSsl,
                //Credentials = new NetworkCredential(smtpEmail, smtpPassword)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true // Set to true if the message is HTML
            };

            // Add each email as a recipient
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }

            // Send email
            return client.SendMailAsync(mailMessage);
        }

      

        public Task SendMailAsync(string email, string username, string password, string subject, string message)
        {
            // Retrieve SMTP settings from appsettings.json
            var smtpEmail = _configuration["SmtpSettings:Email"];
            var smtpPassword = _configuration["SmtpSettings:Password"];
            var smtpHost = _configuration["SmtpSettings:Host"];
            var smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
           // var enableSsl = bool.Parse(_configuration["SmtpSettings:EnableSsl"]);
          
            var client = new SmtpClient(smtpHost, smtpPort)
            {
                //EnableSsl = enableSsl,
                //Credentials = new NetworkCredential(smtpEmail, smtpPassword)
            };

            // Send email
            return client.SendMailAsync(
                new MailMessage(from: smtpEmail, to: email, subject, message));
        }

        //public async Task SenddMailAsync(IEnumerable<string> emails, string subject, string message, IList<IFormFile>? attchements)
        //{
        //    // Retrieve SMTP settings from appsettings.json
        //    try
        //    {
        //        var smtpEmail = _configuration["SmtpSettings:Email"];
        //        var smtpPassword = _configuration["SmtpSettings:Password"];
        //        var smtpHost = _configuration["SmtpSettings:Host"];
        //        var smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
        //        //var enableSsl = bool.Parse(_configuration["SmtpSettings:EnableSsl"]);

        //        var client = new SmtpClient(smtpHost, smtpPort)
        //        {
        //            //EnableSsl = enableSsl,
        //            //Credentials = new NetworkCredential(smtpEmail, smtpPassword)
        //        };

        //        var mailMessage = new MailMessage
        //        {
        //            From = new MailAddress(smtpEmail),
        //            Subject = subject,
        //            Body = message,
        //            IsBodyHtml = true // Set to true if the message is HTML
        //        };

        //        // Add each email as a recipient
        //        foreach (var email in emails)
        //        {
        //            mailMessage.To.Add(email);
        //        }


        //        if (attchements != null && attchements.Count > 0)
        //        {
        //            foreach (var attachment in attchements)
        //            {
        //                if (attachment.Length > 0)
        //                {
        //                    using var memoryStream = new MemoryStream();
        //                    await attachment.CopyToAsync(memoryStream);
        //                    memoryStream.Position = 0;

        //                    var attachmentFile = new Attachment(memoryStream, attachment.FileName);
        //                    mailMessage.Attachments.Add(attachmentFile);
        //                }
        //            }
        //        }

        //        // Send email
        //        await client.SendMailAsync(mailMessage);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}

