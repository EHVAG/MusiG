using StatsHelix.Charizard;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer
{
    public class Authenticated
    {
        protected string CookieGoogleId { get; set; }
        protected int AuthCookieString { get; set; }

        [Middleware]
        public async Task<HttpResponse> VerifyUserSession(HttpRequest req)
        {
            var authHeader = req.GetCookie(Session.AuthHeader);
            bool err = false;

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(authHeader);
            writer.Flush();
            stream.Position = 0;

            using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
            {
                // Create an array to hold the keyed hash value from the session cookie.
                byte[] storedHash = new byte[hmac.HashSize / 8];
                stream.Read(storedHash, 0, storedHash.Length);

                // Create an array to hold the actual message
                byte[] message = new byte[stream.Length - hmac.HashSize / 8];
                stream.Read(storedHash, storedHash.Length, Convert.ToInt32(stream.Length));
                
                // Compute the hash of the remaining contents of the file.
                // The stream is properly positioned at the beginning of the content, 
                // immediately after the stored hash value.
                byte[] computedHash = hmac.ComputeHash(message);

                // compare the computed hash with the stored value
                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        // User is not authenticated anymore
                        return HttpResponse.Redirect(StaticPages.Login);
                    }
                }

                // Verify session age
                var messageString = Encoding.Unicode.GetString(message);
                var index = messageString.IndexOf(' ');
                if (index > 0)
                {
                    DateTimeOffset cookieDateTimeOffset;
                    DateTimeOffset.TryParse(messageString.Substring(index), out cookieDateTimeOffset);
                    if ((DateTimeOffset.UtcNow - cookieDateTimeOffset) > new TimeSpan(1, 30))
                    {

                    }
                }
            }
        }
    }
}
