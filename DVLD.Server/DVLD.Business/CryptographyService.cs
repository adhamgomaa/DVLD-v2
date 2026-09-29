using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public static class CryptographyService
    {
        public static string Hashing(string text)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
        }
    }
}
