using Core.Application.Common.Enums;
using Core.Application.Common.Extensions;

namespace Core.Application.Common.Helpers;

/// <summary>
/// Tarih ve zaman ile ilgili yardımcı fonksiyonlar içerir.<br/>
/// Provides helper functions for date and time operations.
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// UTC zaman diliminde şu anki tarihi döndürür.<br/>
    /// Returns the current date in UTC.
    /// </summary>
    /// <returns>Geçerli UTC zamanı / Current UTC time</returns>
    public static DateTime GetCurrentUtcDate() => DateTime.UtcNow;

    /// <summary>
    /// Bir sonraki iş gününü bulur.<br/>
    /// Finds the next business day starting from the current date.
    /// </summary>
    public static DateTime NextBusinessDay()
    {
        var nextDay = DateTime.Now.AddDays(1);
        while (nextDay.DayOfWeek == DayOfWeek.Saturday || nextDay.DayOfWeek == DayOfWeek.Sunday)
        {
            nextDay = nextDay.AddDays(1);
        }
        return nextDay;
    }

    /// <summary>
    /// Haftanın başlangıcını (Pazartesi) döndürür.<br/>
    /// Returns the start of the current week (Monday).
    /// </summary>
    public static DateTime GetStartOfWeek()
    {
        var today = DateTime.Now;
        int diff = today.DayOfWeek - DayOfWeek.Monday;
        if (diff < 0) diff += 7;
        return today.AddDays(-diff).Date;
    }

    /// <summary>
    /// Haftanın sonunu (Pazar) döndürür.<br/>
    /// Returns the end of the current week (Sunday).
    /// </summary>
    public static DateTime GetEndOfWeek()
    {
        return GetStartOfWeek().AddDays(6);
    }

    /// <summary>
    /// Ayın başlangıcını döndürür.<br/>
    /// Returns the start of the current month.
    /// </summary>
    public static DateTime GetStartOfMonth()
    {
        var today = DateTime.Now;
        return new DateTime(today.Year, today.Month, 1);
    }

    /// <summary>
    /// Ayın sonunu döndürür.<br/>
    /// Returns the end of the current month.
    /// </summary>
    public static DateTime GetEndOfMonth()
    {
        var today = DateTime.Now;
        return new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
    }

    /// <summary>
    /// İki tarih arasındaki gün farkını döner.<br/>
    /// Returns the number of days between two dates.
    /// </summary>
    public static int DaysBetween(DateTime startDate, DateTime endDate)
    {
        return (endDate.Date - startDate.Date).Days;
    }

    /// <summary>
    /// İki tarih arasındaki saat farkını döner.<br/>
    /// Returns the number of hours between two dates.
    /// </summary>
    public static double HoursBetween(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).TotalHours;
    }

    /// <summary>
    /// İki tarih arasındaki dakika farkını döner.<br/>
    /// Returns the number of minutes between two dates.
    /// </summary>
    public static double MinutesBetween(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).TotalMinutes;
    }

    /// <summary>
    /// İki tarih arasındaki toplam farkı ayrıntılı şekilde döner (gün, saat, dakika).<br/>
    /// Returns the total time difference between two dates in days, hours, and minutes.
    /// </summary>
    public static (int Days, int Hours, int Minutes) TotalTimeDifference(DateTime startDate, DateTime endDate)
    {
        var timeSpan = endDate - startDate;
        return (timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
    }

    /// <summary>
    /// UTC tarihini kullanıcının zaman dilimine dönüştürür.<br/>
    /// Converts a UTC date to the user's time zone using a default offset of 180 minutes (UTC+3 for Turkey).
    /// </summary>
    /// <param name="utcDate">UTC olarak kaydedilen tarih / The UTC date</param>
    /// <param name="userOffsetMinutes">Kullanıcının UTC offset değeri dakika olarak (default 180) / User's UTC offset in minutes (default 180)</param>
    /// <returns>Kullanıcının zaman dilimindeki tarih / Date in user's time zone</returns>
    public static DateTime ToUserZone(this DateTime utcDate, int userOffsetMinutes = 180)
    {
        var offsetDifference = TimeSpan.FromMinutes(userOffsetMinutes);
        return utcDate + offsetDifference;
    }

    /// <summary>
    /// Kullanıcının zaman dilimindeki bir tarihi UTC'ye dönüştürür.<br/>
    /// Converts a user's local date to UTC using a default offset of 180 minutes (UTC+3 for Turkey).
    /// </summary>
    /// <param name="localDate">Kullanıcının zaman dilimindeki tarih / User's local date</param>
    /// <param name="userOffsetMinutes">Kullanıcının UTC offset değeri dakika olarak (default 180) / User's UTC offset in minutes (default 180)</param>
    /// <returns>UTC olarak tarih / Date in UTC</returns>
    public static DateTime ToUtcZone(this DateTime localDate, int userOffsetMinutes = 180)
    {
        var offsetDifference = TimeSpan.FromMinutes(userOffsetMinutes);
        return localDate - offsetDifference;
    }
}