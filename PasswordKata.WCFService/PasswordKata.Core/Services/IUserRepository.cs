using PasswordKata.Core;

namespace PasswordKata.Core.Services
{
    public interface IUserRepository
    {
        bool AddUser(string username, string password);

        bool CheckUser(string username, string password);

        User GetUserFromUsername(string username);

        void UpdateUserList();

        bool UpdateUserRepository();
    }
}