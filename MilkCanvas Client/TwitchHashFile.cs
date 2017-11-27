using System;

using JWT;
using JWT.Algorithms;
using JWT.Serializers;

using Newtonsoft.Json;

namespace MilkCanvas_Client
{
    public class TwitchHashFile
    {
        /// <summary>
        /// Access token provided for the end-user
        /// </summary>
        [JsonProperty] private string access_token;
        /// <summary>
        /// JWT Fragment provided by twitch at redirect
        /// </summary>
        [JsonProperty] private string id_token;
        /// <summary>
        /// Scope specified by us at authentication
        /// </summary>
        [JsonProperty] private string scope;
        /// <summary>
        /// OAuth Opaque Token for verification post-authentication to counteract replay attacks
        /// </summary>
        [JsonProperty] private string state;
        /// <summary>
        /// Authentication token type. Should always be "bearer".
        /// </summary>
        [JsonProperty] private string token_type;
        
        private TwitchFragment fragment;

        [JsonIgnore] public string AccessToken => access_token;
        [JsonIgnore] public string Scope => scope;
        [JsonIgnore] public string State => state;
        [JsonIgnore] public string TokenType => token_type;

        [JsonIgnore]
        public TwitchFragment Fragment
        {
            get
            {
                if (fragment == null)
                {
                    var serializer = new JsonNetSerializer();
                    var provider = new UtcDateTimeProvider();
                    var validator = new JwtValidator(serializer, provider);
                    var urlEncoder = new JwtBase64UrlEncoder();
                    var decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    fragment = JsonConvert.DeserializeObject<TwitchFragment>(decoder.Decode(id_token));
                }

                return fragment;
            }
        }
    }
}
