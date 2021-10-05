using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Kata_Core.Models;

namespace Password_Kata_Core.Services
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);
    }
}
