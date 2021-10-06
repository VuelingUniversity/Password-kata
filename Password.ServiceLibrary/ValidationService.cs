using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.ServiceLibrary
{
    public class ValidationService : IValidationService
    {
        private IUserRepository _userRepository;
        private IEncryptionService _encryptionService;

        public ValidationService(IUserRepository userRepository, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            var result = _encryptionService.CheckPassword(user.Salt, password, user.Password);
            return result;
        }
    }
}