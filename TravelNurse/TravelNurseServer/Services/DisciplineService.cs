
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos.Common.Get;

namespace TravelNurseServer.Services;

public interface IDisciplineService
{
    Task<List<GetDisciplineDto>> GetDisciplines();
    
    Task<List<GetDisciplineSpecialtyDto>> GetDisciplineSpecialties(int disciplineId);
    
    Task<List<GetSubSpecialtyDto>> GetSubSpecialties(int specialtyId);
}


public class DisciplineService: IDisciplineService
{
    private readonly IDbContextFactory<DataContext> _context;
    private readonly IMapper _mapper;
    
    public DisciplineService(
        IDbContextFactory<DataContext> context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetDisciplineDto>> GetDisciplines()
    {
        await using var context = await _context.CreateDbContextAsync();
        
        var data = await context.Disciplines.ToListAsync();
        var res = _mapper.Map<List<GetDisciplineDto>>(data);
        return res;
    }
    
    public async Task<List<GetDisciplineSpecialtyDto>> GetDisciplineSpecialties(int disciplineId)
    {
        await using var context = await _context.CreateDbContextAsync();
        var data = await context.DisciplineSpecialties
            .Include(x => x.Specialty)
            .Where(x => x.DisciplineId == disciplineId)
            .ToListAsync();
        
        return _mapper.Map<List<GetDisciplineSpecialtyDto>>(data);
    }

    public async Task<List<GetSubSpecialtyDto>> GetSubSpecialties(int specialtyId)
    {
        await using var context = await _context.CreateDbContextAsync();
        var data = await context.SubSpecialties
            .Where(x => x.SpecialtyId == specialtyId)
            .ToListAsync();
        
        return _mapper.Map<List<GetSubSpecialtyDto>>(data);

    }
}