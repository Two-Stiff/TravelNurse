using AutoMapper;
using TravelNurseServer.Dtos.Jobs.Add;
using TravelNurseServer.Dtos.Jobs.Get;

namespace TravelNurse.Components.Common;

public class UiAutoMapperProfile : Profile
{
    public UiAutoMapperProfile()
    {
        CreateMap<GetJobDto, AddJobDto>().ReverseMap();
    }
}