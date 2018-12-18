using Newtonsoft.Json;
using RestSharp;
using WPFSampleApp.Models;

namespace WPFSampleApp.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly Options _options;

        public ProjectRepository(Options options)
        {
            _options = options;
        }

        public ProjectRepository()
        {
            _options = new Options();
        }

        public Project GetLatestProjectInfoById(long Id)
        {
            var client = new RestClient(_options.ProjectBaseUrl + Id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + GetToken());
            var response = client.Execute<Project>(request);
            return response.Data;
        }

        private string GetToken()
        {
            var client = new RestClient(_options.AuthBaseUrl);
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(_options.APICredentials), ParameterType.RequestBody);
            var response = client.Execute<TokenContainer>(request);
            return response.Data.Token;
        }
    }
}