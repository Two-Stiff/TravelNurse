using AutoMapper;
using TravelNurseServer.Dtos.Jobs.Add;
using TravelNurseServer.Dtos.Jobs.Get;
using TravelNurseServer.Dtos.Providers.Add;
using TravelNurseServer.Dtos.Providers.Get;
using TravelNurseServer.Dtos.Providers.Update;

namespace TravelNurse.Components.Common;

public class UiAutoMapperProfile : Profile
{
    public UiAutoMapperProfile()
    {
        CreateMap<GetJobDto, AddJobDto>().ReverseMap();
        
        CreateMap<GetProviderDto, UpdateProviderGeneralInformationDto>().ReverseMap();
    }
}