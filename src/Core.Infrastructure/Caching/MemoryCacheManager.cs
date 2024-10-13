using Core.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Infrastructure.Caching;

public class MemoryCacheManager : ICacheManager
{
    private readonly IMemoryCache _cache;

    public MemoryCacheManager(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        _cache.Set(key, value, expiration);
        return Task.CompletedTask;
    }

    public Task<T> GetAsync<T>(string key)
    {
        _cache.TryGetValue(key, out T value);
        return Task.FromResult(value);
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }
}
