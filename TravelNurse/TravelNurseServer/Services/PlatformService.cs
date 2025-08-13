using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.Platforms.Get;

namespace TravelNurseServer.Services;

public interface IPlatformService
{
    Task<List<GetPlatformDto>> GetPlatform();
}

public class PlatformService: IPlatformService
{
    private readonly IDbContextFactory<DataContext> _context;
    private readonly IMapper _mapper;
    
    public PlatformService(
        IDbContextFactory<DataContext> context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetPlatformDto>> GetPlatform()
    {
        await using var context = await _context.CreateDbContextAsync();
        var data = await context.Platforms.ToListAsync();
        return _mapper.Map<List<GetPlatformDto>>(data);
    }
}