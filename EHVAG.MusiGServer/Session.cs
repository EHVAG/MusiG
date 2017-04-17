using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EHVAG.MusiGServer
{
    public class Session
    {
        public const String GoogleIdHeader = "GoogleTokenId";
        public const String AuthHeader = "AuthId";
        private static readonly byte[] SecretKey;

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

        public static string GenerateSessionCookie(string googleId)
        {
            var stringToSign = googleId + " " + DateTimeOffset.UtcNow;
            using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
            {
                // Compute the hash of the input file.
                return (hmac.ComputeHash(Encoding.Unicode.GetBytes(stringToSign))).ToString();
            }
        }

        public static bool VerifySessionCookie(string sessionCookie)
        {
            bool err = false;
            // Initialize the keyed hash object. 
            using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
            {
                var sessionByte = Encoding.ASCII.GetBytes(sessionCookie.ToCharArray());

                // Create an array to hold the keyed hash value from the session cookie.
                byte[] storedHash = new byte[hmac.HashSize / 8];
                byte[] message = new byte[sessionByte.Length - hmac.HashSize / 8];

                Array.Copy(sessionByte, storedHash, storedHash.Length);
                Array.Copy(sessionByte, storedHash.Length, message, 0, sessionByte.Length);

                // Compute the hash of the remaining contents of the file.
                // The stream is properly positioned at the beginning of the content, 
                // immediately after the stored hash value.
                byte[] computedHash = hmac.ComputeHash(message);
                // compare the computed hash with the stored value

                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        err = true;
                    }
                }
            }
            if (err)
            {
                Console.WriteLine("Hash values differ! Signed file has been tampered with!");
                return false;
            }
            else
            {
                Console.WriteLine("Hash values agree -- no tampering occurred.");
                return true;
            }

        }
    }
}
