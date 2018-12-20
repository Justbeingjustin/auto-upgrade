using AutoMapper;

namespace Upgrades.API
{
    public class UpgradesProfile : Profile
    {
        public UpgradesProfile()
        {
            CreateMap<Models.ProjectForCreation, Entities.Project>();
            CreateMap<Models.ProjectForUpdate, Entities.Project>();
        }
    }
}