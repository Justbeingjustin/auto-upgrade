using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upgrades.API.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string LatestAssemblyVersionNumber { get; set; }

        public string AutoUpdaterXMLPath { get; set; }
    }
}