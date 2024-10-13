using System.ComponentModel;
using System.Reflection;

namespace Core.Application.Common.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Bir enum değerinin Description attribute'ünü döner. <br/>
    /// Eğer Description attribute'u yoksa, enum değerinin string temsilini döner.
    /// 
    /// Returns the Description attribute of an enum value. 
    /// If the Description attribute is not present, returns the string representation of the enum value.
    /// </summary>
    /// <param name="value">Enum değeri / Enum value</param>
    /// <returns>Description değeri veya enum string temsili / The Description value or enum string representation</returns>
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)field?.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute?.Description ?? value.ToString();
    }
}