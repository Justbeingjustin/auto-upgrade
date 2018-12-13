using Microsoft.AspNetCore.Identity;

namespace Upgrades.API.Entities
{
    public class UpgradeUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}