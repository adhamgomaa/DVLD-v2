using DVLD.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
