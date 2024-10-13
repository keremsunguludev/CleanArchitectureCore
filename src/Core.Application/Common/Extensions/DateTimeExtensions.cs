using Core.Application.Common.Enums;

namespace Core.Application.Common.Extensions;

public static class DateTimeExtensions
{
    private const string DefaultSeparator = "/";

    /// <summary>
    /// Tarihi enum ile belirtilen format ve isteğe bağlı separator değişikliği ile formatlar.<br/>
    /// Formats the DateTime using enum and optional separator replacement.
    /// </summary>
    /// <param name="date">Formatlanacak tarih / Date to format</param>
    /// <param name="format">Enum ile belirtilen format / Enum value for format</param>
    /// <param name="separator">İsteğe bağlı separator / Optional separator (default: /)</param>
    /// <returns>Formatlanmış tarih / Formatted date string</returns>
    public static string FormatDate(this DateTime date, DateFormat format, string separator = DefaultSeparator)
    {
        string formatString = format.GetDescription();

        if (separator != DefaultSeparator)
        {
            formatString = formatString.Replace(DefaultSeparator, separator);
        }

        return date.ToString(formatString);
    }

    /// <summary>
    /// Tarihi custom format string ile formatlar.<br/>
    /// Formats the DateTime using a custom format string.
    /// </summary>
    /// <param name="date">Formatlanacak tarih / Date to format</param>
    /// <param name="format">Custom format dizesi / Custom format string</param>
    /// <returns>Formatlanmış tarih / Formatted date string</returns>
    public static string FormatDate(this DateTime date, string format)
    {
        return date.ToString(format);
    }

    /// <summary>
    /// Belirtilen tarihin hafta sonu olup olmadığını kontrol eder.<br/>
    /// Checks if the given date falls on a weekend.
    /// </summary>
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    /// <summary>
    /// Belirtilen tarihin iş günü olup olmadığını kontrol eder.<br/>
    /// Checks if the given date is a business day (not a weekend).
    /// </summary>
    public static bool IsBusinessDay(this DateTime date)
    {
        return !IsWeekend(date);
    }
}