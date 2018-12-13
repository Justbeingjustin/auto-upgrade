using Microsoft.EntityFrameworkCore;
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

        public async Task<Project> GetProjectByIdAsync(long projectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.OrderBy(x => x.ProjectName).ToListAsync();
        }
    }
}