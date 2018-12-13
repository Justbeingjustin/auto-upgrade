using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upgrades.API.Entities;
using Upgrades.API.Services;

namespace Upgrades.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IProjectsRepository _projectsRepository;
        private UserManager<UpgradeUser> _userManager;

        public ProjectsController(IProjectsRepository projectsRepository, UserManager<UpgradeUser> userManager)
        {
            _projectsRepository = projectsRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Project> organizationEntities = await _projectsRepository.GetProjectsAsync();
            return Ok(organizationEntities);
        }

        [HttpGet]
        [Route("{projectId}", Name = "GetProjectById")]
        public async Task<IActionResult> GetProjectById(long projectId)
        {
            var project = await _projectsRepository.GetProjectByIdAsync(projectId);

            return Ok(project);
        }
    }
}