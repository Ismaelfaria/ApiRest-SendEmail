using System.Net.Mail;
using System.Net;

namespace ProcessoSeletivo_API.Service
{
    public class ServiceEmail : IServiceEmail
    {
        private readonly IConfiguration _configuration;
        public ServiceEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string SmtpAddress => _configuration["EmailSettings:SmtpAddress"];
        private int PortNumber => int.Parse(_configuration["EmailSettings:PortNumber"]);
        private string EmailFromAddress => _configuration["EmailSettings:EmailFromAddress"];
        private string Password => _configuration["EmailSettings:Password"];

        public void AddEmailsToMailmensager(MailMessage mailMessage, string email)
        {
            mailMessage.To.Add(email);
        }

        public void SendEmail(string email, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(EmailFromAddress);
                AddEmailsToMailmensager(mailMessage, email);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(SmtpAddress, PortNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(EmailFromAddress, Password);
                    smtp.Send(mailMessage);
                }
            }
        }

    }
}
