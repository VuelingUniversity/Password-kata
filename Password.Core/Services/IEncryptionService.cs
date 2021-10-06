using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Core.Services
{
    public interface IEncryptionService
    {
        bool CheckPassword(string salt, string password, string encryptedPassword);

        string EncryptPassword(string password, string salt);
    }
}