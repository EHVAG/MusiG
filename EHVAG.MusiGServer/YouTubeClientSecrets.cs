using Newtonsoft.Json;

namespace EHVAG.MusiGServer
{
    // TODO: Make it globally accessible
    // TODO: Add checks 
    public static class YouTubeClientSecret
    {
        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("auth_uri")]
        public int AuthUri { get; set; }

        [JsonProperty("token_uri")]
        public int TokenUri { get; set; }

        [JsonProperty("auth_provider_x509_cert_url")]
        public int AuthProviderX509CertUrl { get; set; }

        [JsonProperty("client_secret")]
        public int ClientSecret { get; set; }

        [JsonProperty("redirect_uris")]
        public int RedirectUris { get; set; }

        [JsonProperty("javascript_origins")]
        public int JavascriptOrigins { get; set; }

        [JsonProperty("scope")]
        public int Scope { get; set; }

        [JsonProperty("response")]
        public int Response { get; set; }

        [JsonProperty("access_type")]
        public int AccessType { get; set; }

        [JsonProperty("grant_type")]
        public int GrantType { get; set; }
    }
}
