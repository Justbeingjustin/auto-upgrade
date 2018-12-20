using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upgrades.API.Contexts;
using Upgrades.API.Entities;

namespace Upgrades.API.Services
{
    public class ProjectsRepository : IProjectsRepository
    {
        private UpgradeContext _context;

        public ProjectsRepository(UpgradeContext context)
        {
            _context = context;
        }

        public void AddProject(Project projectToAdd)
        {
            if (projectToAdd == null)
            {
                throw new ArgumentNullException(nameof(projectToAdd));
            }

            _context.Add(projectToAdd);
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task<Project> GetProjectByIdAsync(long projectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.OrderBy(x => x.ProjectName).ToListAsync();
        }

        public bool ProjectExists(long projectId)
        {
            return _context.Projects.Any(x => x.ProjectId == projectId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}