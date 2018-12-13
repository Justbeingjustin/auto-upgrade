using Newtonsoft.Json;

namespace Upgrades.Models
{
    public class APICredentials
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}