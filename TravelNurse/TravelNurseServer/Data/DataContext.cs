using Core.Data;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Entities.Common;
using TravelNurseServer.Entities.Providers;

namespace TravelNurseServer.Data;

public class DataContext : DatabaseContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Provider> Providers => Set<Provider>();
    
    public DbSet<Discipline> Disciplines => Set<Discipline>();
    
    public DbSet<DisciplineSpecialty> DisciplineSpecialties => Set<DisciplineSpecialty>();
    
    public DbSet<Specialty> Specialties => Set<Specialty>();
    
    public DbSet<State> States => Set<State>();
    
    public DbSet<SubSpecialty> SubSpecialties => Set<SubSpecialty>();
    

}