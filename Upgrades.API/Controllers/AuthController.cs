using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Upgrades.API.Contexts;
using Upgrades.API.Entities;
using Upgrades.API.Filters;
using Upgrades.API.Models;

namespace Upgrades.API.Controllers
{
    public class AuthController : Controller
    {
        private UpgradeContext _context;
        private UserManager<UpgradeUser> _userManager;
        private IPasswordHasher<UpgradeUser> _hasher;
        private ConfigSettings _configSettings;
        private RoleManager<IdentityRole> _roleManager;

        public AuthController(UpgradeContext context,
          SignInManager<UpgradeUser> signInMgr,
          UserManager<UpgradeUser> userManager,
          IPasswordHasher<UpgradeUser> hasher,
          ConfigSettings configSettings, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _hasher = hasher;
            _configSettings = configSettings;
            _roleManager = roleManager;
        }

        [ValidateModelAttribute]
        [HttpPost("api/auth/token")]
        public async Task<IActionResult> CreateToken([FromBody] CredentialModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                    {
                        var userClaims = await _userManager.GetClaimsAsync(user);

                        var claims = new[]
                        {
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
          new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
          new Claim(JwtRegisteredClaimNames.Email, user.Email)
        }.Union(userClaims);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configSettings.Configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                          issuer: _configSettings.Configuration["Tokens:Issuer"],
                          audience: _configSettings.Configuration["Tokens:Audience"],
                          claims: claims,
                          expires: DateTime.UtcNow.AddMinutes(15),
                          signingCredentials: creds
                          );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO Log
            }

            return BadRequest("Failed to generate token");
        }
    }
}