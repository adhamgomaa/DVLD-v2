using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Helpers
{
    public static class Encryption
    {
        public static string Hashing(string text)
        {
            byte[] hashByte = SHA256.HashData(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
        }
    }
}
