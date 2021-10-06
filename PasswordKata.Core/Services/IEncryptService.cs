namespace PassworKata.ServiceLIbrary
{
    public interface IEncryptService
    {
        bool CheckPassword(string salt, string password, string encryptedPassword);
        string EncryptPassword(string password, string salt);
    }
}