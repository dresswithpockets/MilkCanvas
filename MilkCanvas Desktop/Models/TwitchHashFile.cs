namespace MilkCanvas.Models
{
    using JWT;
    using JWT.Serializers;

    using Newtonsoft.Json;

    public class TwitchHashFile
    {
        // ignore CS0649 because we're using JsonConvert to serialize these fields, and we're not assigning them manually.
        // ignore SA1310 because the JSON schema for a hash file matches these names, so we have to use underscores.
#pragma warning disable CS0649, SA1310
        [JsonProperty]
        private string access_token;

        [JsonProperty]
        private string id_token;

        [JsonProperty]
        private string scope;

        [JsonProperty]
        private string state;

        [JsonProperty]
        private string token_type;
#pragma warning restore CS0649

        private TwitchFragment fragment;

        /// <summary>
        /// Gets the access token provided for the end-user.
        /// </summary>
        [JsonIgnore]
        public string AccessToken => this.access_token;

        /// <summary>
        /// Gets the scope specified by us at authentication
        /// </summary>
        [JsonIgnore]
        public string Scope => this.scope;

        /// <summary>
        /// Gets the OAuth Opaque Token used in verification during post-authentication to counteract replay attacks
        /// </summary>
        [JsonIgnore]
        public string State => this.state;

        /// <summary>
        /// Gets the authentication token type. Should always be "bearer".
        /// </summary>
        [JsonIgnore]
        public string TokenType => this.token_type;

        /// <summary>
        /// Gets the JSONWebToken Fragment provided by twitch after redirect.
        /// This contains important information like the user's userid.
        /// </summary>
        [JsonIgnore]
        public TwitchFragment Fragment
        {
            get
            {
                if (this.fragment == null)
                {
                    var serializer = new JsonNetSerializer();
                    var provider = new UtcDateTimeProvider();
                    var validator = new JwtValidator(serializer, provider);
                    var urlEncoder = new JwtBase64UrlEncoder();
                    var decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    this.fragment = JsonConvert.DeserializeObject<TwitchFragment>(decoder.Decode(this.id_token));
                }

                return this.fragment;
            }
        }
    }
}
