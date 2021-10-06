using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Kata_Core.Services;

namespace Password_Kata_ServiceLibrary
{
    public class ValidatePasswordService : IValidatePasswordService
    {
        private IUserRepository _userRepository;
        private IEncryptService _encryptService;
        public ValidatePasswordService(IUserRepository userRepository, IEncryptService encryptService)
        {
            _userRepository = userRepository;
            _encryptService = encryptService;
        }
        
        public bool ValidateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName)) return false;
            if (string.IsNullOrEmpty(password)) return false;
            var user = _userRepository.GetUserByName(userName);
            if (user == null) return false;
            var result = _encryptService.CheckPassword(user.Salt, password, user.Password);
            return result;
        }
        public bool ValidateUser2(string userName, string password)
        {
            var user = _userRepository.GetUserByName(userName);
            var newEncryptedPassword = _encryptService.EncryptPassword(password, user.Salt);
            return newEncryptedPassword == user.Password;
        }

    }
}
