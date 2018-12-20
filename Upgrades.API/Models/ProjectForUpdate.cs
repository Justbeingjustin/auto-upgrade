using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upgrades.API.Models
{
    public class ProjectForUpdate
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string LatestAssemblyVersionNumber { get; set; }

        public string AutoUpdaterXMLPath { get; set; }
    }
}