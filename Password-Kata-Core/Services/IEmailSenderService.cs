using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Kata_Core.Services
{
    public interface IEmailSenderService
    {
        void SendResetEmail(string email, string message);
    }
}
