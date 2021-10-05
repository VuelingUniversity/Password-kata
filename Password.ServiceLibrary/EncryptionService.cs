using Password.Core.Services;
using Password.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Password.ServiceLibrary
{
    public class EncryptionService : IEncryptionService
    {
        private IUserRepository _userRepository;

        public EncryptionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidatePassword(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);

            if (user == null)
            {
                return false;
            }
            return user.Password.Equals(EncryptPassword(password, user.Salt));
        }

        public string EncryptPassword(string password, string salt)
        {
            byte[] hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }
    }
}