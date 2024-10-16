namespace Core.Application.Interfaces;

public interface ICacheService
{
    /// <summary>
    /// Cache'ten verilen anahtar ile veri alır.
    /// Get the data from the cache with the given key.
    /// </summary>
    /// <typeparam name="T">Veri tipi / Data type</typeparam>
    /// <param name="key">Anahtar / Key</param>
    /// <returns>Cache'teki veri / Data from cache</returns>
    ValueTask<T?> GetAsync<T>(string key);

    /// <summary>
    /// Cache'e veri ekler veya günceller.
    /// Add or update data in the cache.
    /// </summary>
    /// <typeparam name="T">Veri tipi / Data type</typeparam>
    /// <param name="key">Anahtar / Key</param>
    /// <param name="value">Eklenecek veri / Data to add</param>
    /// <param name="expiration">Verinin ne kadar süre cache'te kalacağı / The expiration time for the cached data</param>
    Task SetAsync<T>(string key, T value, TimeSpan expiration);

    /// <summary>
    /// Cache'ten belirli anahtarı siler.
    /// Remove the data with the specified key from the cache.
    /// </summary>
    /// <param name="key">Anahtar / Key</param>
    Task RemoveAsync(string key);

    /// <summary>
    /// Verilen anahtarın cache'te olup olmadığını kontrol eder.
    /// Check if the given key exists in the cache.
    /// </summary>
    /// <param name="key">Anahtar / Key</param>
    ValueTask<bool> ExistsAsync(string key);
}
