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
        private string salt;
        public ValidatePasswordService(IUserRepository userRepository, IEncryptService encryptService)
        {
            _userRepository = userRepository;
            _encryptService = encryptService;
        }
        public bool ValidatePassword(string userName, string password)
        {
            var user = _userRepository.GetUserByName(userName);
            if (user == null)
                return false;
            return user.Password.Equals(_encryptService.EncryptPassword(password, salt));
        }
    }
}
