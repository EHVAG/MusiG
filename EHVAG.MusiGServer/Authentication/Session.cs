using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EHVAG.MusiGServer
{
    public static class Session
    {
        public const String GoogleIdHeader = "GoogleUserId";
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
            if (!string.IsNullOrEmpty(sessionId))
            {
                var message = sessionId + " " + DateTimeOffset.UtcNow;
                using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
                {
                    var computedHmac = hmac.ComputeHash(Encoding.ASCII.GetBytes(message));
                    var convertedHmac = BitConverter.ToString(computedHmac).Replace("-", "");

                    // Return computed HMAC plus original message
                    return convertedHmac + " " + message;
                }
            }
            return String.Empty;
        }
    }
}
