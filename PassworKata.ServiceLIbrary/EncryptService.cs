using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassworKata.ServiceLIbrary
{
    public class EncryptService : IEncryptService
    {
        public bool CheckPassword(string salt, string password, string encryptedPassword)
        {
            return encryptedPassword.Equals(EncryptPassword(password, salt));
        }
        public string EncryptPassword(string password, string salt)
        {
            byte[] hashalgorithm = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            return string.Concat(hashalgorithm.Select(b => b.ToString("X2")));
        }
    }
}
