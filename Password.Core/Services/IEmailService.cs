using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Core.Services
{
    public interface IEmailService
    {
        void SendResetEmail(string email);
    }
}