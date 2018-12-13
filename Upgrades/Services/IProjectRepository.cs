using Upgrades.Models;

namespace Upgrades.Services
{
    public interface IProjectRepository
    {
        Project GetLatestProjectInfoById(long Id);
    }
}