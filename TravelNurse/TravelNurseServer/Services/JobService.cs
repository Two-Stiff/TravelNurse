using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.Jobs.Get;

namespace TravelNurseServer.Services;


public interface IJobService
{
    // Task AddJob(AddJobDto addTravelerDto);
    //
    // Task<DataGridListItemDto<GetJobDto>> GetJobDataGrid<T>(GridDataRequestDto<T> state, List<DataGridFilterDto> filters);
    
    Task<List<GetJobDto>> GetJobs();
}


public class JobService : IJobService
{
    private readonly IDbContextFactory<DataContext> _context;
    private readonly IMapper _mapper;
    
    public JobService(
        IDbContextFactory<DataContext> context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetJobDto>> GetJobs()
    {
        await using var context = await _context.CreateDbContextAsync();
        
        var data = await context.Jobs.ToListAsync();
        var res = _mapper.Map<List<GetJobDto>>(data);
        return res;
    }
}