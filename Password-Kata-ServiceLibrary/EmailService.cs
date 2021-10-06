using Password_Kata_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Kata_ServiceLibrary
{
    public class EmailService : IEmailService
    {
        private IUserRepository _userRepository;
        private IEmailSenderService _emailSenderService;
        public EmailService(IUserRepository userRepository, IEmailSenderService emailSenderService)
        {
            _userRepository = userRepository;
            _emailSenderService = emailSenderService;
        }
        public void SendResetEmail(string email)
        {
            if (_userRepository.EmailExistInRepo(email))
            {
                string emailMessage = $"Validation Link: -----";
                _emailSenderService.SendEmail(email, emailMessage);
            }

        }
    }
}
