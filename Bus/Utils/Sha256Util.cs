using System;
using System.Security.Cryptography;
using System.Text;

namespace Bus.Utils
{
    public static class Sha256Util
    {
        public static string Encrypt(string str)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(str));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}