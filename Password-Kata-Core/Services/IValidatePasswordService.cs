using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Kata_Core.Services
{
    public interface IValidatePasswordService
    {
        bool ValidateUser(string userName, string password);
        bool ValidateUser2(string userName, string password);
    }
}
