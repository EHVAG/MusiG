using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EHVAG.MusiGServer
{
    public static class Session
    {
        public const String GoogleIdHeader = "GoogleTokenId";
        public const String AuthHeader = "AuthId";
        public static readonly byte[] SecretKey;

        static Session()
        {
            try
            {
                SecretKey = File.ReadAllBytes(@"Config\Crypto\SecretKey.key");
            }
            catch (Exception exep)
            {
                Console.WriteLine(exep.Message);
            }
        }

        public static string SignSession(string sessionId)
        {
            sessionId += " " + DateTimeOffset.UtcNow;
            using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
            {
                // Compute the hash of the input file.
                return (hmac.ComputeHash(Encoding.Unicode.GetBytes(sessionId))).ToString();
            }
        }
    }
}
