using DVLD.Business.Interfaces;

namespace DVLD.Business.Implementations
{
    public sealed class CryptographyService : ICryptographyService
    {
        public string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
