using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Upgrades.API.Entities;

namespace Upgrades.API.Contexts
{
    public class UpgradeContext : IdentityDbContext<UpgradeUser>
    {
        public UpgradeContext(DbContextOptions<UpgradeContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}