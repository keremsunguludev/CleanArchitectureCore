using Core.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;


namespace Core.Infrastructure.Caching;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    // Okuma işlemi için ValueTask kullanıyoruz
    public ValueTask<T?> GetAsync<T>(string key)
    {
        if (_memoryCache.TryGetValue(key, out T value))
        {
            return new ValueTask<T?>(value);
        }
        return new ValueTask<T?>(default(T?));
    }

    // Yazma işlemi için Task kullanıyoruz
    public Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(expiration); // Sliding expiration kullanılıyor

        _memoryCache.Set(key, value, cacheEntryOptions);

        return Task.CompletedTask;
    }

    // Silme işlemi için Task kullanıyoruz
    public Task RemoveAsync(string key)
    {
        _memoryCache.Remove(key);
        return Task.CompletedTask;
    }

    // Varlık kontrolü için ValueTask kullanıyoruz
    public ValueTask<bool> ExistsAsync(string key)
    {
        return new ValueTask<bool>(_memoryCache.TryGetValue(key, out _));
    }
}
