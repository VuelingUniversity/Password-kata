using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Password.Infra
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient _smtpClient;

        public EmailSender()
        {
            // url de un servidor de correos (con gmail seria smtp.gmail.com)
            _smtpClient = new SmtpClient("smtp.ethereal.email")
            {
                Port = 587,
                // nombre de usuario y contraseña para iniciar sesión en el servidor de correos (no tiene porque ser el email)
                Credentials = new NetworkCredential("juliet.morar61@ethereal.email", "ShTaayR4nYsr8JfxjQ"),
                EnableSsl = true,
            };
        }

        public void SendResetEmail(string email, string message)
        {
            // email de quien envia, email de quien recibe, asunto, mensaje
            _smtpClient.Send("admin@gmail.com", "usuario@gmail.com", "asunto", $"{message}");
        }
    }
}