using StatsHelix.Charizard;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer
{
    public class Authenticated
    {
        protected string GoogleId { get; set; }
        protected string AuthCookie { get; set; }

        [Middleware]
        public Task<HttpResponse> VerifyUserSession(HttpRequest request)
        {
            AuthCookie = request.GetCookie(Session.AuthHeader);

            if (!string.IsNullOrEmpty(AuthCookie))
            {
                using (HMACSHA256 hmac = new HMACSHA256(Session.SecretKey))
                {
                    // Get the HMAC and the original message from the cookie
                    var storedHmac = AuthCookie.Substring(0, 64);
                    var storedMessage = AuthCookie.Substring(65);

                    // Compute the hash of the original message.
                    byte[] computedHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(storedMessage));

                    // compare the computed hash with the stored value.
                    if (BitConverter.ToString(computedHash).Replace("-", "") != storedHmac)
                    {
                        // User is not authenticated anymore.
                        return Task.FromResult(HttpResponse.Redirect(StaticPages.Login));
                    }

                    // Get the timestamp from the AuthHeader.
                    var index = storedMessage.IndexOf(' ');
                    if (index > 0)
                    {
                        DateTimeOffset cookieDateTimeOffset;
                        DateTimeOffset.TryParse(storedMessage.Substring(index), out cookieDateTimeOffset);

                        // Check if the AuthHeader is older than one hour.
                        if ((DateTimeOffset.UtcNow - cookieDateTimeOffset) > new TimeSpan(1, 0, 0))
                        {
                            return Task.FromResult(HttpResponse.Redirect(StaticPages.Login));
                        }
                    }

                    // Save the users GoogleId for future API calls.
                    GoogleId = storedMessage.Substring(0, index);

                    // Every check passed.
                    return null;
                }
            }
            // No cookie
            return Task.FromResult(HttpResponse.Redirect(StaticPages.InternalServerError));
        }
    }
}
