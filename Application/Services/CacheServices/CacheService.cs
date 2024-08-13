using Application.IServices.ICacheServices;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services.CacheServices
{
    public class InMemoryCacheService<T> : ICacheService<T>
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async void AddToCache(string cacheKey, T value)
        {
            _cache.Set(cacheKey, value, TimeSpan.FromHours(1));
        }

        public T GetValueFromCache(string cacheKey)
        {
            if (_cache.TryGetValue(cacheKey, out T cacheValue))
            {
                return cacheValue;
            }

            return default;
        }
    }
}
