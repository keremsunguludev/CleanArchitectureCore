using System.ComponentModel;

namespace Core.Application.Common.Enums;

/// <summary>
/// Farklı tarih formatlarını temsil eden DateFormat enum'u, tarihler için standart formatlar sağlar.<br/>
/// Varsayılan separator "/" olup, istenirse başka bir separator ile değiştirilebilir.
///
/// The DateFormat enum represents different date formats and provides standardized date formatting.
/// The default separator is "/", but it can be replaced with a custom separator.
/// </summary>
public enum DateFormat
{
    [Description("dd/MM/yyyy")]
    ShortDate,

    [Description("dddd, dd MMMM yyyy")]
    LongDate,

    [Description("yyyy/MM/dd")]
    IsoDate,

    [Description("yyyy/MM/dd HH:mm:ss")]
    FullDateTime
}