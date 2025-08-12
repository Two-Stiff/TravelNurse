using System.ComponentModel;

namespace TravelNurse.Components.Common.Enums;

public enum DataFetchEnum
{
    [Description("Platforms")]
    Platforms = 0,

    [Description("Disciplines")]
    Disciplines = 1,

    [Description("Facilities")]
    Facilities = 2,

    [Description("Specialties")]
    Specialties = 3,

    [Description("SubSpecialties")]
    SubSpecialties = 4,

    [Description("Contacts")]
    Contacts = 5,

    [Description("JobBoardCertificationTypes")]
    JobBoardCertificationTypes = 6,

    [Description("JobBoardLicenseTypes")]
    JobBoardLicenseTypes = 7,
    

    [Description("RateTypes")]
    RateTypes = 9,
}