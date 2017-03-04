using Newtonsoft.Json;

namespace EHVAG.MusiGServer
{
    // TODO: Make it globally accessible
    // TODO: Add checks 
    public static class YouTubeClientSecret
    {
        [JsonProperty("client_id")]
        public static string ClientId { get; set; }

        [JsonProperty("project_id")]
        public static string ProjectId { get; set; }

        [JsonProperty("auth_uri")]
        public static string AuthUri { get; set; }

        [JsonProperty("token_uri")]
        public static string TokenUri { get; set; }

        [JsonProperty("auth_provider_x509_cert_url")]
        public static string AuthProviderX509CertUrl { get; set; }

        [JsonProperty("client_secret")]
        public static string ClientSecret { get; set; }

        [JsonProperty("redirect_uris")]
        public static string RedirectUris { get; set; }

        [JsonProperty("javascript_origins")]
        public static string JavascriptOrigins { get; set; }

        [JsonProperty("scope")]
        public static string Scope { get; set; }

        [JsonProperty("response")]
        public static string Response { get; set; }

        [JsonProperty("access_type")]
        public static string AccessType { get; set; }

        [JsonProperty("grant_type")]
        public static string GrantType { get; set; }
    }
}
