namespace Upgrades.API.Models
{
    public class ProjectForCreation
    {
        public string ProjectName { get; set; }

        public string LatestAssemblyVersionNumber { get; set; }

        public string AutoUpdaterXMLPath { get; set; }
    }
}