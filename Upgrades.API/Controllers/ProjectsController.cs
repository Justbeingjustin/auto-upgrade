using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upgrades.API.Entities;
using Upgrades.API.Models;
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
        private IMapper _mapper;

        public ProjectsController(IProjectsRepository projectsRepository, UserManager<UpgradeUser> userManager, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _userManager = userManager;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectForCreation projectForCreation)
        {
            var projectEntity = _mapper.Map<Entities.Project>(projectForCreation);
            _projectsRepository.AddProject(projectEntity);

            await _projectsRepository.SaveChangesAsync();

            // Fetch (refetch) the project from the data store
            await _projectsRepository.GetProjectByIdAsync(projectEntity.ProjectId);

            return CreatedAtRoute("GetProjectById",
                new { projectId = projectEntity.ProjectId },
                projectEntity);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(long projectId, [FromBody] ProjectForUpdate projectForUpdate)
        {
            try
            {
                if (projectForUpdate == null)
                {
                    return BadRequest();
                }

                var projectEntity = await _projectsRepository.GetProjectByIdAsync(projectId);

                if (projectEntity == null)
                {
                    return NotFound();
                }

                projectEntity.ProjectName = projectForUpdate.ProjectName;
                projectEntity.LatestAssemblyVersionNumber = projectForUpdate.LatestAssemblyVersionNumber;
                projectEntity.AutoUpdaterXMLPath = projectForUpdate.AutoUpdaterXMLPath;

                //companySettingEntity = _mapper.Map<Entities.CompanySetting>(companySettingDTO);

                if (!(await _projectsRepository.SaveChangesAsync()))
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(long projectId)
        {
            if (!_projectsRepository.ProjectExists(projectId))
            {
                return NotFound();
            }

            var projectEntity = await _projectsRepository.GetProjectByIdAsync(projectId);
            if (projectEntity == null)
            {
                return NotFound();
            }

            _projectsRepository.DeleteProject(projectEntity);

            if (!(await _projectsRepository.SaveChangesAsync()))
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }
    }
}