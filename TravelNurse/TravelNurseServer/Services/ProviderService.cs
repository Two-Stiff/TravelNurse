using System.Linq.Expressions;
using AutoMapper;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.DataGridDtos;
using TravelNurseServer.Dtos.Providers.Get;
using TravelNurseServer.Dtos.Providers.Update;
using TravelNurseServer.Dtos.TablePaginationParams;
using TravelNurseServer.Entities.Providers;
using TravelNurseServer.Helpers;


namespace TravelNurseServer.Services;

public interface IProviderService
{
    Task<GetProviderDto> GetProviderById(int id);
    
    Task<DataGridListItemDto<GetProviderDto>> GetProviderDataGrid<T>(GridDataRequestDto<T> state, List<DataGridFilterDto> filters);

    Task<GetProviderDto> UpdateProvider(int id, UpdateProviderGeneralInformationDto updateProviderGeneralInformationDto);
    
}

public class ProviderService : IProviderService
{
    private readonly IDbContextFactory<DataContext> _context;
    private readonly IMapper _mapper;
    
    public ProviderService(
        IDbContextFactory<DataContext> context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetProviderDto> GetProviderById(int id)
    {
        await using var context = await _context.CreateDbContextAsync();
        var provider = await context.Providers
            .Include(x => x.Discipline)
            .Include(x => x.Specialty)
            .GetAsync(id);
        var res = _mapper.Map<GetProviderDto>(provider);
        return res;
    }
    
    public async Task<DataGridListItemDto<GetProviderDto>> GetProviderDataGrid<T>(GridDataRequestDto<T> state,
        List<DataGridFilterDto> filters)
    {
        var providerFilterPredicates = new List<Expression<Func<Provider, bool>>>();
        foreach (var filter in filters)
            if (filter?.Value != null && !string.IsNullOrEmpty(filter.PropertyName) && !string.IsNullOrEmpty(filter.Operator))
            {
                var predicate = ExpressionBuilder.BuildPredicate<Provider>(
                    filter.PropertyName,
                    filter.Operator,
                    filter.Value
                );
                providerFilterPredicates.Add(predicate);
            }

        var providerFilterList = ExpressionBuilder.AndAll(providerFilterPredicates.ToArray());

        await using var context = await _context.CreateDbContextAsync();
        
        var providers = await context.Providers
            .Include(x => x.Discipline)
            .Where(providerFilterList)
            .OrderBy(x => x.Id)
            .Skip(state.Page * state.PageSize)
            .Take(state.PageSize)
            .ToListAsync();

        var providerCount =
            await context.Providers
                .Where(providerFilterList).CountAsync();

        var items = _mapper.Map<List<GetProviderDto>>(providers);

        return new DataGridListItemDto<GetProviderDto>
        {
            Items = items,
            ItemTotalCount = providerCount
        };
    }

    public async Task<GetProviderDto> UpdateProvider(int id, UpdateProviderGeneralInformationDto updateProviderGeneralInformationDto)
    {
        await using var context = await _context.CreateDbContextAsync();
        var provider = await context.Providers
            .Include(x => x.Discipline)
            .Include(x => x.Specialty)
            .GetAsync(id);
        
        provider.PrimaryPhoneNumber = updateProviderGeneralInformationDto.PrimaryPhoneNumber;
        provider.Email = updateProviderGeneralInformationDto.Email;
        provider.StreetAddress = updateProviderGeneralInformationDto.StreetAddress;
        provider.City = updateProviderGeneralInformationDto.City;
        provider.ZipCode = updateProviderGeneralInformationDto.ZipCode;
        provider.DisciplineId = updateProviderGeneralInformationDto.DisciplineId;
        provider.SpecialtyId   = updateProviderGeneralInformationDto.SpecialtyId;
        
        if (updateProviderGeneralInformationDto.AvailabilityDate.HasValue)
        {
            provider.AvailabilityDate = updateProviderGeneralInformationDto.AvailabilityDate.Value;
        }
        
        
        await context.SaveChangesAsync();
        
        var specialty = await context.Specialties.GetAsync(updateProviderGeneralInformationDto.SpecialtyId);
        var discipline = await context.Disciplines.GetAsync(updateProviderGeneralInformationDto.DisciplineId);
        provider.Discipline = discipline;
        provider.Specialty = specialty;
        var mappedResult = _mapper.Map<GetProviderDto>(provider);
        return mappedResult;
    }
}