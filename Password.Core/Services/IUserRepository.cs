using Password.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password.Core.Services
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}