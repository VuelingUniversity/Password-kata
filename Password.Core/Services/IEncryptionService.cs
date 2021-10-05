using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Core.Services
{
    public interface IEncryptionService
    {
        bool ValidatePassword(string username, string password);

        string EncryptPassword(string password, string salt);
    }
}