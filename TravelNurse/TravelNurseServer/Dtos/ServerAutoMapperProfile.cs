using AutoMapper;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Entities.Common;
namespace TravelNurseServer.Dtos;

public class ServerAutoMapperProfile : Profile
{
    public ServerAutoMapperProfile()
    {
        CreateMap<Discipline, GetDisciplineDto>().ReverseMap();
        CreateMap<DisciplineSpecialty, GetDisciplineSpecialtyDto>().ReverseMap();
        CreateMap<Specialty, GetSpecialtyDto>().ReverseMap();
        CreateMap<SubSpecialty, GetSubSpecialtyDto>().ReverseMap();
    }
}