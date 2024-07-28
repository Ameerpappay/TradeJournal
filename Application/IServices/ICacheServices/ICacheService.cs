using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.ICacheServices
{
    public interface ICacheService<T>
    {
        T GetValueFromCache(string cacheKey);

        void AddToCache(string cacheKey, T value);
    }
}
