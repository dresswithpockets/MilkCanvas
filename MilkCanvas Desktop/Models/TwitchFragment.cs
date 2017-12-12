namespace MilkCanvas.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// A representation of the parsed JSONWebToken that Twitch provides in the redirect post-authentication.
    /// </summary>
    public class TwitchFragment
    {
        // ignore CS0649 because we're using JsonConvert to serialize these fields.
#pragma warning disable CS0649
        [JsonProperty]
        private string iss;

        [JsonProperty]
        private string sub;

        [JsonProperty]
        private string aud;

        [JsonProperty]
        private string exp;

        [JsonProperty]
        private string iat;

        [JsonProperty]
        private string nonce;
#pragma warning restore CS0649

        /// <summary>
        /// Gets the token issuer (Twitch)
        /// </summary>
        [JsonIgnore]
        public string Issuer => this.iss;

        /// <summary>
        /// Gets the subject or end-user identifier
        /// </summary>
        [JsonIgnore]
        public string Subject => this.sub;

        /// <summary>
        /// Gets the audience or OAuth 2.0 client that is the intended recipient of the token
        /// </summary>
        [JsonIgnore]
        public string Audience => this.aud;

        /// <summary>
        /// Gets the expiration time (note that when the JWT ID tokens expire, they cannot be refreshed)
        /// </summary>
        [JsonIgnore]
        public string Expriationtime => this.exp;

        /// <summary>
        /// Gets the issuance time
        /// </summary>
        [JsonIgnore]
        public string IssuanceTime => this.iat;

        /// <summary>
        /// Gets the OIDC Opaque Token for verification post-authentication to counteract replay attacks
        /// </summary>
        [JsonIgnore]
        public string Nonce => this.nonce;
    }
}
