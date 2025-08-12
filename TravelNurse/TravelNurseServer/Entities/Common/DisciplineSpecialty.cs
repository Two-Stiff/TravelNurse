using Core;

namespace TravelNurseServer.Entities.Common;

public class DisciplineSpecialty : Entity
{
    public int DisciplineId { get; set; }

    public Discipline? Discipline { get; set; }

    public int SpecialtyId { get; set; }

    public Specialty? Specialty { get; set; }
}