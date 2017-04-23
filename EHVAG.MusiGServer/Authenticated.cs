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
        protected string GoogleId { get; set; }
        protected string AuthCookieString { get; set; }

        [Middleware]
        public Task<HttpResponse> VerifyUserSession(HttpRequest request)
        {
            AuthCookieString = request.GetCookie(Session.AuthHeader);

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(AuthCookieString);
            writer.Flush();
            stream.Position = 0;

            using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
            {
                // Create an array to hold the keyed hash value from the session cookie.
                byte[] storedHash = new byte[hmac.HashSize / 8];
                stream.Read(storedHash, 0, storedHash.Length);

                // Create an array to hold the actual message.
                byte[] message = new byte[stream.Length - hmac.HashSize / 8];
                stream.Read(storedHash, storedHash.Length, Convert.ToInt32(stream.Length));
                
                // Compute the hash of the message.
                byte[] computedHash = hmac.ComputeHash(message);

                // compare the computed hash with the stored value.
                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        // User is not authenticated anymore.
                        return Task.FromResult(HttpResponse.Redirect(StaticPages.Login));
                    }
                }

                // Get the timestamp from the AuthHeader.
                // This tells us how old the session is.
                // Since the "message" part is just an id + a timestamp Encoding.Unicode should do the job.
                var messageString = Encoding.Unicode.GetString(message);
                var index = messageString.IndexOf(' ');
                if (index > 0)
                {
                    DateTimeOffset cookieDateTimeOffset;
                    DateTimeOffset.TryParse(messageString.Substring(index), out cookieDateTimeOffset);

                    // Check if the AuthHeader is older than one hour.
                    if ((DateTimeOffset.UtcNow - cookieDateTimeOffset) > new TimeSpan(1))
                    {
                        return Task.FromResult(HttpResponse.Redirect(StaticPages.Login));
                    }
                }

                // Save the users GoogleId for future API calls.
                GoogleId = messageString.Substring(0, index);

                // Every checked passed.
                return null;
            }
        }
    }
}
