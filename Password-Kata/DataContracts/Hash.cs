using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Password_Kata.DataContracts
{
    public class Hash
    {
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
        public Hash()
        {
            var password = "mypassword123!";
            var newSalt = GenerateSalt();
            var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytesnewSalt));
        }
    }
}