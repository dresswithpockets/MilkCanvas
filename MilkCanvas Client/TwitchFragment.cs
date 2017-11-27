using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MilkCanvas_Client
{
    public class TwitchFragment
    {
        [JsonProperty] private string iss;
        [JsonProperty] private string sub;
        [JsonProperty] private string aud;
        [JsonProperty] private string exp;
        [JsonProperty] private string iat;
        [JsonProperty] private string nonce;

        /// <summary>
        /// Token issuer (Twitch)
        /// </summary>
        [JsonIgnore] public string Issuer => iss;
        /// <summary>
        /// Subject or end-user identifier
        /// </summary>
        [JsonIgnore] public string Subject => sub;
        /// <summary>
        /// Audience or OAuth 2.0 client that is the intended recipient of the token
        /// </summary>
        [JsonIgnore] public string Audience => aud;
        /// <summary>
        /// Expiration time (note that when the JWT ID tokens expire, they cannot be refreshed)
        /// </summary>
        [JsonIgnore] public string Expriationtime => exp;
        /// <summary>
        /// Issuance time
        /// </summary>
        [JsonIgnore] public string IssuanceTime => iat;
        /// <summary>
        /// OIDC Opaque Token for verification post-authentication to counteract replay attacks
        /// </summary>
        [JsonIgnore] public string Nonce => nonce;
    }
}
