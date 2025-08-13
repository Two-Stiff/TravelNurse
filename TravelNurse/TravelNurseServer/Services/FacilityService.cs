using System.Text.RegularExpressions;
using AutoMapper;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.Common.Get;
using TravelNurseServer.Entities.Common;

namespace TravelNurseServer.Services;

public interface IFacilityService
{
    Task<List<GetFacilityDto>> GetFacilities(string name);
}

public class FacilityService: IFacilityService
{
    private readonly IDbContextFactory<DataContext> _context;
    private readonly IMapper _mapper;
    
    public FacilityService(
        IDbContextFactory<DataContext> context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetFacilityDto>> GetFacilities(string text)
    {
        var isPureNumber = Regex.IsMatch(text, @"^\d+$");
        var isPureString = Regex.IsMatch(text, @"^[^\d]+$");
        var isAlphanumericMixed = Regex.IsMatch(text, @"^(?=.*[A-Za-z])(?=.*\d).+$");

        await using var context = await _context.CreateDbContextAsync();
        var data = await context.Facilities
            .If(isPureNumber && !isPureString && !isAlphanumericMixed, x => x.Where(y => y.Id == int.Parse(text)))
            .If(!isPureNumber && isPureString && !isAlphanumericMixed, x => x.Where(y => y.Name .ToLower().Contains(text)))
            .Take(20)
            .SelectOnly(x => new Facility()
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync();
        var res = _mapper.Map<List<GetFacilityDto>>(data);
        return res;
    }
}