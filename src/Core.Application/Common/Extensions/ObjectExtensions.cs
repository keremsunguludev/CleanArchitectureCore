using System.Text.Json;

namespace Core.Application.Common.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Herhangi bir objenin klonunu oluşturur.<br/>
    /// Creates a clone of any object using System.Text.Json for serialization.
    /// </summary>
    /// <typeparam name="T">Klonlanacak nesne tipi / Type of the object to clone</typeparam>
    /// <param name="source">Klonlanacak nesne / The object to clone</param>
    /// <returns>Klonlanmış nesne / Cloned object</returns>
    public static T Clone<T>(this T source)
    {
        if (source == null)
        {
            return default;
        }

        // JSON serileştirme ve deserialization ile klonlama
        return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(source));
    }
}
