using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upgrades.API.Entities;

namespace Upgrades.API.Services
{
    public interface IProjectsRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();

        Task<Project> GetProjectByIdAsync(long projectId);
    }
}