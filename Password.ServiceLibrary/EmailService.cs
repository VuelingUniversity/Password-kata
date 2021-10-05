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

        public EmailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SendResetEmail(string email)
        {
            if (_userRepository.IsEmailValid(email))
            {
                Console.WriteLine("Enviado email de recuperacion de la contraseña");
            }
        }
    }
}