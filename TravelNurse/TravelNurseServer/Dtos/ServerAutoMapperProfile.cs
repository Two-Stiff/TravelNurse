using AutoMapper;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Dtos.Jobs.Add;
using TravelNurseServer.Dtos.Jobs.Get;
using TravelNurseServer.Dtos.Platforms.Get;
using TravelNurseServer.Dtos.Providers.Get;
using TravelNurseServer.Entities.Common;
using TravelNurseServer.Entities.Jobs;
using TravelNurseServer.Entities.Platforms;
using TravelNurseServer.Entities.Providers;

namespace TravelNurseServer.Dtos;

public class ServerAutoMapperProfile : Profile
{
    public ServerAutoMapperProfile()
    {

        #region Get
        CreateMap<Discipline, GetDisciplineDto>().ReverseMap();
        CreateMap<DisciplineSpecialty, GetDisciplineSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, GetSpecialtyDto>().ReverseMap();
        CreateMap<SubSpecialty, GetSubSpecialtyDto>().ReverseMap();
        CreateMap<State, GetStateDto>().ReverseMap();
        
        CreateMap<Facility, GetFacilityDto>().ReverseMap();
        CreateMap<Job, GetJobDto>().ReverseMap();
        CreateMap<Provider, GetProviderDto>().ReverseMap();
        CreateMap<Platform, GetPlatformDto>().ReverseMap();

        #endregion
        
        
        #region Add

        CreateMap<Job, AddJobDto>().ReverseMap();
        CreateMap<JobSubSpecialty, AddJobSubSpecialtyDto>().ReverseMap();
        #endregion
    }
}