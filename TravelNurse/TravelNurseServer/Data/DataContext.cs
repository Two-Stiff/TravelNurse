using Core.Data;
using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Entities.Common;
using TravelNurseServer.Entities.Jobs;
using TravelNurseServer.Entities.Platforms;
using TravelNurseServer.Entities.Providers;

namespace TravelNurseServer.Data;

public class DataContext (DbContextOptions<DataContext> options) : DbContext(options)
{
    // public DataContext(DbContextOptions<DataContext> options) : base(options)
    // {
    //     
    // }
    //
    public DbSet<Provider> Providers => Set<Provider>();
    
    public DbSet<Discipline> Disciplines => Set<Discipline>();
    
    public DbSet<DisciplineSpecialty> DisciplineSpecialties => Set<DisciplineSpecialty>();
    
    public DbSet<Specialty> Specialties => Set<Specialty>();
    
    public DbSet<State> States => Set<State>();
    
    public DbSet<SubSpecialty> SubSpecialties => Set<SubSpecialty>();
    
    public DbSet<Facility> Facilities => Set<Facility>();
    
    public DbSet<Job> Jobs => Set<Job>();
    
    public DbSet<JobSubSpecialty> JobSubSpecialties => Set<JobSubSpecialty>();
    
    public DbSet<Platform> Platforms => Set<Platform>();
    
}