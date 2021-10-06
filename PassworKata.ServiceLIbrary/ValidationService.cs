using PasswordKata.Core.Models;
using PasswordKata.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassworKata.ServiceLIbrary
{
    public class ValidationService : IValidationService
    {
        public IEncryptService _encryptService;
        public IUsersRepository _userRepository;

        public ValidationService(IEncryptService encryptService, IUsersRepository userRepository)
        {
            _encryptService = encryptService;
            _userRepository = userRepository;
        }
        public bool ValidatePassword(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var userGeted = _userRepository.GetUserByUsername(user);
            return _encryptService.CheckPassword(userGeted.Salt, password, userGeted.Password);
        }
    }
}
