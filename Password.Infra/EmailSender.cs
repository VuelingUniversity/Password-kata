using Password.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Infra
{
    public class EmailSender : IEmailSender
    {
        public void SendResetEmail(string email, string message)
        {
            Console.WriteLine(message);
        }
    }
}