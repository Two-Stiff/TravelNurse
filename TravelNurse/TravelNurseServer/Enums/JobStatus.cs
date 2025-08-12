namespace TravelNurseServer.Enums;

public enum JobStatus
{
    Approved = 1, // Good Job with all details needed
    Partial = 2, // Jobs with incomplete data
    Closed = 3, // Jobs with incomplete data which are not required to be posted
    Rejected = 4 // Jobs that directly gets rejected because of some Opti conditions
}