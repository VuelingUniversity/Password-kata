namespace PasswordKata.ServiceLibrary.Services
{
    public interface IEncryptService
    {
        string GetHashPassword(string password);
    }
}