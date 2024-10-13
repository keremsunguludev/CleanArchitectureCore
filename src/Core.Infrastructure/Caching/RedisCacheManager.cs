using StackExchange.Redis;
using Core.Infrastructure.Interfaces;

namespace Core.Infrastructure.Caching;


public class RedisCacheManager : ICacheManager
{
    private readonly IDatabase _database;

    public RedisCacheManager(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var jsonData = System.Text.Json.JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, jsonData, expiration);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var data = await _database.StringGetAsync(key);
        return data.HasValue ? System.Text.Json.JsonSerializer.Deserialize<T>(data) : default;
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}
