using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Kata_Core.Services;
using System.Security.Cryptography;

namespace Password_Kata_ServiceLibrary
{
    public class EncryptService : IEncryptService
    {
      
        public EncryptService()
        {
            
        }
        public string ComputeHash(byte[] bytesToHash, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }    
        public string EncryptPassword(string password, string salt)
        {
            //var newSalt = GenerateSalt();
            var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt));
            return hashedPassword;
        }
        public bool CheckPassword(string salt, string password, string encryptedPassword)
        {
            return encryptedPassword.Equals(EncryptPassword(password, salt));
        }
    }
}
