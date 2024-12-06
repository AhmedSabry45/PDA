

namespace PDA.Interceptor
{
  
        public interface IMailService
        {
           // Task SendMailAsync(MailContent mailContent, IList<IFormFile>? attachments = null);
            Task SendMailAsync(IEnumerable<string> emails, string subject,string message);

       


        Task SendMailAsync(string email, string username, string password, string subject, string message);

     


        }
    
}
