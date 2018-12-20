namespace WPFSampleApp.Models
{
    public class Options
    {
        public string AuthBaseUrl { get; set; } = "https://localhost:44337/api/auth/token";
        public string ProjectBaseUrl { get; set; } = "https://localhost:44337/api/Projects/";
        public APICredentials APICredentials { get; set; } = new APICredentials() { Username = "Justbeingjustin", Password = "P@ssw0rd!" };
    }
}