namespace Child.Growth.src.Services.Interfaces
{
    public interface ICryptographyService
    {
        string DecryptPassword(string base64);

        string CryptographyPassword(string password);
    }
}