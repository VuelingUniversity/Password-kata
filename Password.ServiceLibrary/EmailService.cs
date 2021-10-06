using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.ServiceLibrary
{
    public class EmailService : IEmailService
    {
        private IUserRepository _userRepository;
        private IEmailSender _emailSender;

        public EmailService(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public void SendResetEmail(string email)
        {
            if (_userRepository.IsEmailValid(email))
            {
                string message = "Hola el link para resetear la constraseña es xxx";
                _emailSender.SendResetEmail(email, message);
            }
        }
    }
}