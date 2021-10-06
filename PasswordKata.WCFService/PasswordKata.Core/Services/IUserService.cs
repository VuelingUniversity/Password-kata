namespace PasswordKata.Core.Services
{
    public interface IUserService
    {
        bool AddUser(string username, string password);

        bool CheckUser(string username, string password);
    }
}