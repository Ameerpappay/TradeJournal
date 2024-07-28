namespace Application.IServices.ICacheServices
{
    public interface ICacheService<T>
    {
        T GetValueFromCache(string cacheKey);

        void AddToCache(string cacheKey, T value);
    }
}
