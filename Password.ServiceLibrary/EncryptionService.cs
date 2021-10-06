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
        public bool CheckPassword(string salt, string password, string encryptedPassword)
        {
            return encryptedPassword.Equals(EncryptPassword(password, salt));
        }

        public string EncryptPassword(string password, string salt)
        {
            byte[] hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }
    }
}