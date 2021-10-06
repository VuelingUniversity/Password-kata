using PasswordKata.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKata.Core.services
{
    public interface IValidationRepository
    {
        List<User> GetUserList();
    }
}