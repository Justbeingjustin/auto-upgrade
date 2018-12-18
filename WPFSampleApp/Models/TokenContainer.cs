using Newtonsoft.Json;
using System;

namespace WPFSampleApp.Models
{
    public class TokenContainer
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}