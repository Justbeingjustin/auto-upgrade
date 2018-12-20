using Newtonsoft.Json;

namespace WPFSampleApp.Models
{
    public class APICredentials
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}