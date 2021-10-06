using PasswordKata.Core.Models;

namespace PasswordKata.InfraStructure.Repositories
{
    public interface IUsersRepository
    {
        Users GetUserByUsername(string username);
        bool IsEmailValid(string email);
    }
}