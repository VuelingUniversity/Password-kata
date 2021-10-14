using PasswordKata.Core;
using System.Collections.Generic;

namespace PasswordKata.Core.Services
{
    public interface IUserRepository
    {
        bool AddUser(string username, string password);

        bool CheckUser(string username, string password);

        User GetUserFromUsername(string username);

        void UpdateUserList();

        bool UpdateUserRepository();
        List<string> GetUsers();
    }
}