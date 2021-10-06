namespace PassworKata.ServiceLIbrary
{
    public interface IValidationService
    {
        bool ValidatePassword(string user, string password);
    }
}