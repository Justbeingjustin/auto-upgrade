using System.ComponentModel.DataAnnotations;

namespace Upgrades.API.Models
{
    public class CredentialModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}