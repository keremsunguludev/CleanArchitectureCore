using System.Text.Json;
using Core.Application.Interfaces;
using StackExchange.Redis;

namespace Core.Infrastructure.Caching;


public class RedisCacheService : ICacheService
{
    private readonly IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    /// <summary>
    /// Verilen anahtarla cache'ten veri alır.
    /// Get the data from the cache with the given key.
    /// </summary>
    /// <typeparam name="T">Veri tipi / Data type</typeparam>
    /// <param name="key">Anahtar / Key</param>
    /// <returns>Cache'teki veri / Data from cache</returns>
    public async ValueTask<T?> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);

        if (!value.IsNullOrEmpty)
        {
            return JsonSerializer.Deserialize<T>(value);
        }

        return default(T?);
    }

    /// <summary>
    /// Cache'e veri ekler veya günceller.
    /// Add or update data in the cache.
    /// </summary>
    /// <typeparam name="T">Veri tipi / Data type</typeparam>
    /// <param name="key">Anahtar / Key</param>
    /// <param name="value">Eklenecek veri / Data to add</param>
    /// <param name="expiration">Verinin ne kadar süre cache'te kalacağı / The expiration time for the cached data</param>
    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var serializedValue = JsonSerializer.Serialize(value);

        await _database.StringSetAsync(key, serializedValue, expiration);
    }

    /// <summary>
    /// Cache'ten belirli anahtarı siler.
    /// Remove the data with the specified key from the cache.
    /// </summary>
    /// <param name="key">Anahtar / Key</param>
    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

    /// <summary>
    /// Verilen anahtarın cache'te olup olmadığını kontrol eder.
    /// Check if the given key exists in the cache.
    /// </summary>
    /// <param name="key">Anahtar / Key</param>
    /// <returns>Cache'te var mı? / Whether the key exists in the cache</returns>
    public async ValueTask<bool> ExistsAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }
}
