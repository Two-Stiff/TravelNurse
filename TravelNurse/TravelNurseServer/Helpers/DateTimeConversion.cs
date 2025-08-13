namespace TravelNurseServer.Helpers;

public static class DateTimeConversion
{
    public static DateTime ToUtcSafe(this DateTime dateTime)
    {
        return dateTime.Kind switch
        {
            DateTimeKind.Utc => dateTime,
            DateTimeKind.Local => dateTime.ToUniversalTime(),
            DateTimeKind.Unspecified => TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.Local),
            _ => dateTime
        };
    }
}