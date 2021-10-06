using PasswordKata.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.ServiceLibrary.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IEncryptService _encryptService;

        public UserService(IUserRepository userRepository, IEncryptService encryptService)
        {
            _userRepository = userRepository;
            _encryptService = encryptService;
        }

        public bool CheckUser(string username, string password)
        {
            return _userRepository.CheckUser(username, _encryptService.GetHashPassword(password));
        }

        public bool AddUser(string username, string password)
        {
            return _userRepository.AddUser(username, _encryptService.GetHashPassword(password));
        }
    }
}