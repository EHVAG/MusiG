using System;
using System.Collections;
using System.Collections.Generic;

namespace EHVAG.MusiGModel
{
    public class AuthScheme
    {
        /// <summary>
        /// Determines whether the Google OAuth 2.0 endpoint returns an authorization code.
        /// Web server applications should use code.
        /// </summary>
        public string AuthUrl { get; set; }

        /// <summary>
        /// Determines whether the Google OAuth 2.0 endpoint returns an authorization code. 
        /// Web server applications should use code.
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// Identifies the client that is making the request. The value passed in this parameter must exactly match the value shown in the Google API Console.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Determines where the response is sent. 
        /// The value of this parameter must exactly match one of the values listed for this project in the Google API Console (including the http or https scheme, case, and trailing '/').
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Identifies the Google API access that your application is requesting.
        /// The values passed in this parameter inform the consent screen that is shown to the user.
        /// There is an inverse relationship between the number of permissions requested and the likelihood of obtaining user consent. 
        /// For information about available login scopes, see Login scopes.To see the available scopes for all Google APIs, visit the APIs Explorer. 
        /// It is generally a best practice to request scopes incrementally, at the time access is required, rather than up front. 
        /// For example, an app that wants to support purchases should not request Google Wallet access until the user presses the “buy” button; 
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Provides any state that might be useful to your application upon receipt of the response.
        /// The Google Authorization Server roundtrips this parameter, so your application receives the same value it sent.
        /// To mitigate against cross-site request forgery (CSRF), it is strongly recommended to include an anti-forgery token in the state, and confirm it in the response. 
        /// See OpenID Connect for an example of how to do this.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Indicates whether your application needs to access a Google API when the user is not present at the browser. This parameter defaults to online. If your application needs to refresh access tokens when the user is not present at the browser, then use offline. This will result in your application obtaining a refresh token the first time your application exchanges an authorization code for a user.
        /// </summary>
        public string AccessType { get; set; }

        /// <summary>
        /// Possible values:
        /// none - Do not display any authentication or consent screens.Must not be specified with other values.
        /// consent - Prompt the user for consent
        /// select_account - Prompt the user to select an account
        /// </summary>
        public string Promt { get; set; }

        /// <summary>
        /// When your application knows which user it is trying to authenticate, it can provide this parameter as a hint to the Authentication Server.
        /// Passing this hint will either pre-fill the email box on the sign-in form or select the proper multi-login session, thereby simplifying the login flow.
        /// </summary>
        public string LoginHint { get; set; }

        /// <summary>
        /// If this is provided with the value true, and the authorization request is granted, the authorization will include any previous authorizations granted to this user/application combination for other scopes; see Incremental Authorization.
        /// </summary>
        public string IncludeGrantedScopes { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
    }
}