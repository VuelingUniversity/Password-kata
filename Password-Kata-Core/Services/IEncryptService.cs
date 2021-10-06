using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Kata_Core.Services
{
    public interface IEncryptService
    {
        string ComputeHash(byte[] bytesToHash, byte[] salt);
        string GenerateSalt();
        string EncryptPassword(string password, string salt);
        bool CheckPassword(string salt, string password, string encryptedPassword);
    }
}
