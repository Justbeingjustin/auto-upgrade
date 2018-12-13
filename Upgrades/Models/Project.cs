namespace Upgrades.Models
{
    public class Project
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string LatestAssemblyVersionNumber { get; set; }

        public string AutoUpdaterXMLPath { get; set; }
    }
}