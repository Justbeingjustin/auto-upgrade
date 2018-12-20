using WPFSampleApp.Models;

namespace WPFSampleApp.Services
{
    public interface IProjectRepository
    {
        Project GetLatestProjectInfoById(long Id);
    }
}