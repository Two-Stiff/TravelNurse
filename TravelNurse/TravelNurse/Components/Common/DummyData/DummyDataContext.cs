using TravelNurseServer.Helpers;

namespace TravelNurse.Components.Common.DummyData;

public static class DummyDataContext
{
    public static List<SelectOption> GetDummyCertifications()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = 1,
                Name = "BLS",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "ACLS",
                Selected = false
            }
        };
    }

    public static List<SelectOption> GetDummyStateLicenses()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = 1,
                Name = "Nebraska",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "California",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "Iowa",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "Colorado",
                Selected = false
            }
        };
    }

    public static List<SelectOption> GetPlatforms()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = 1,
                Name = "LinkedIn",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "Glassdoor",
                Selected = false
            }
        };
    }

    public static List<SelectOption> GetFacilities()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = -1,
                Name = "Please select an option",
                Selected = false
            },
            new()
            {
                Id = 1,
                Name = "Alta Bates Summit Medical Center - Summit Campus",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "KP Kula Hospital",
                Selected = false
            }
        };
    }

    public static List<SelectOption> GetContacts()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = -1,
                Name = "Please select an option",
                Selected = false
            },
            new()
            {
                Id = 1,
                Name = "Kat Williams",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "Dave Chappelle",
                Selected = false
            }
        };
    }

    public static List<SelectOption> GetShiftPerWeek()
    {
        return new List<SelectOption>
        {
            new()
            {
                Id = -1,
                Name = "Please select an option",
                Selected = false
            },
            new()
            {
                Id = 1,
                Name = "1 shift per week",
                Selected = false
            },
            new()
            {
                Id = 2,
                Name = "2 shifts per week",
                Selected = false
            },
            new()
            {
                Id = 3,
                Name = "3 shifts per week",
                Selected = false
            },
            new()
            {
                Id = 4,
                Name = "4 shifts per week",
                Selected = false
            },
            new()
            {
                Id = 5,
                Name = "5 shifts per week",
                Selected = false
            },
            new()
            {
                Id = 6,
                Name = "6 shifts per week",
                Selected = false
            },
            new()
            {
                Id = 7,
                Name = "7 shifts per week",
                Selected = false
            }
        };
    }
}