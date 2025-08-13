using System.Linq.Expressions;
using AutoMapper;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.DataGridDtos;
using TravelNurseServer.Dtos.Jobs.Add;
using TravelNurseServer.Dtos.Jobs.Get;
using TravelNurseServer.Dtos.TablePaginationParams;
using TravelNurseServer.Entities.Jobs;
using TravelNurseServer.Enums;
using TravelNurseServer.Helpers;

namespace TravelNurseServer.Services;


public interface IJobService
{
    Task AddJob(AddJobDto addTravelerDto);
    //
    Task<DataGridListItemDto<GetJobDto>> GetJobDataGrid<T>(GridDataRequestDto<T> state, List<DataGridFilterDto> filters);
    
    Task<List<GetJobDto>> GetJobs();
    
    Task<GetJobDto> GetJob(int id);

    Task UpdateJob(int id, AddJobDto addJobDto);
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

    public async Task<GetJobDto> GetJob(int id)
    {
        await using var context = await _context.CreateDbContextAsync();
        
        var data = await context.Jobs.GetAsync(id);
        var res = _mapper.Map<GetJobDto>(data);
        return res;
    }
    
    public async Task<List<GetJobDto>> GetJobs()
    {
        await using var context = await _context.CreateDbContextAsync();
        
        var data = await context.Jobs.ToListAsync();
        var res = _mapper.Map<List<GetJobDto>>(data);
        return res;
    }
    
    public async Task<DataGridListItemDto<GetJobDto>> GetJobDataGrid<T>(GridDataRequestDto<T> state,
        List<DataGridFilterDto> filters)
    {
        var jobFilterPredicates = new List<Expression<Func<Job, bool>>>();
        foreach (var filter in filters)
            if (filter?.Value != null && !string.IsNullOrEmpty(filter.PropertyName) && !string.IsNullOrEmpty(filter.Operator))
            {
                var predicate = ExpressionBuilderV2.BuildPredicate<Job>(
                    filter.PropertyName,
                    filter.Operator,
                    filter.Value
                );
                jobFilterPredicates.Add(predicate);
            }

        var jobFilterList = ExpressionBuilderV2.AndAll(jobFilterPredicates.ToArray());

        await using var context = await _context.CreateDbContextAsync();
        
        
        var jobs = await context.Jobs
            .Include(x => x.Discipline)
            .Where(jobFilterList)
            .OrderBy(x => x.Id)
            .Skip(state.Page * state.PageSize)
            .Take(state.PageSize)
            .ToListAsync();

        var jobsCount =
            await context.Jobs
                .Where(jobFilterList).CountAsync();

        var items = _mapper.Map<List<GetJobDto>>(jobs);

        return new DataGridListItemDto<GetJobDto>
        {
            Items = items,
            ItemTotalCount = jobsCount
        };
    }
    
    public async Task AddJob(AddJobDto addJobDto)
    {
        await using var context = await _context.CreateDbContextAsync();

        var job = _mapper.Map<Job>(addJobDto);

        job.StartDate = job.StartDate.ToUtcSafe();
        job.ExpiresOn = job.ExpiresOn.ToUtcSafe();
        
        await context.Jobs.AddAsync(job);
        await context.SaveChangesAsync();
        

        var subSpecialties = new List<AddJobSubSpecialtyDto>();
        foreach (var item in addJobDto.SelectedSubSpecialties)
        {
            subSpecialties.Add(new AddJobSubSpecialtyDto()
            {
                JobId = job.Id,
                SubSpecialtyId = item.Id,
                IsRequired = item.Selected
            });
        }
        var data = _mapper.Map<List<JobSubSpecialty>>(subSpecialties);

        await context.JobSubSpecialties.AddRangeAsync(data);
        await context.SaveChangesAsync();

    }

    public async Task UpdateJob(int id, AddJobDto addJobDto)
    {
        await using var context = await _context.CreateDbContextAsync();
        var job = await context.Jobs
            .Include(x => x.JobSubSpecialties)
            .GetAsync(id);
        
        job.JobTitle = addJobDto.JobTitle;
        job.StartDate = addJobDto.StartDate.Value.ToUtcSafe();
        job.ExpiresOn = addJobDto.ExpiresOn.Value.ToUtcSafe();
        job.UniqueNotes = addJobDto.UniqueNotes;
        job.FacilityId = addJobDto.FacilityId;
        job.DisciplineId = addJobDto.DisciplineId;
        job.SpecialtyId = addJobDto.SpecialtyId;
        job.JobType = (JobType)addJobDto.JobType;
        job.AllowsAutoposterUpdate = addJobDto.AllowsAutoposterUpdate.Value;
        job.HousingProvided = addJobDto.HousingProvided.Value;
        job.AutoPosted = addJobDto.AutoPosted.Value;
        job.HideExternally = addJobDto.HideExternally.Value;
        job.PlatformId = addJobDto.PlatformId;
        job.ContractLengthWeeks = addJobDto.ContractLengthWeeks.Value;
        
        await context.SaveChangesAsync();

    }
}