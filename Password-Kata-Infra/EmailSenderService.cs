using Password_Kata_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Password_Kata_Infra
{
    public class EmailSenderService : IEmailSenderService
    {
        private SmtpClient _smtpClient;
        public EmailSenderService()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("email@gmail.com", "password"),
                EnableSsl = true,
            };  
        }
        public void SendEmail(string email, string message)
        {
            _smtpClient.Send("email", "recipient", "subject", "body");
        }
    }
}
