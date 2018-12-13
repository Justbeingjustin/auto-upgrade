using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upgrades.API
{
    public class ConfigSettings
    {
        public IConfiguration Configuration { get; set; }

        public ConfigSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}