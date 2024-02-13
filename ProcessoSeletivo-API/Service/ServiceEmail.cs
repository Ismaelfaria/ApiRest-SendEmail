using System.Net.Mail;
using System.Net;

namespace ProcessoSeletivo_API.Service
{
    public class ServiceEmail:IServiceEmail
    {
        private string smtpAddress => "smtp.gmail.com";
        private int portNumber => 587;
        private string emailFromAddress => "limaismael8901@gmail.com";
        private string password => "wfgu ukxr xxgc afou";

        public void AddEmailsToMailmensager(MailMessage mailMessage, string email)
        {
                mailMessage.To.Add(email);
        }

        public void SendEmail(string email)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAddress);
                AddEmailsToMailmensager(mailMessage, email);
                mailMessage.Subject = "PROCESSO SELETIVO";
                mailMessage.Body = "Seu cadastro foi realizado!!!";
                mailMessage.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.Send(mailMessage);
                }
            }
        }

    }
}
