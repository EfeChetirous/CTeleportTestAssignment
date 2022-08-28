using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Core.Cache
{
    public interface ICacheManager<T> where T : class
    {
        T Get<T>(string cacheKey);
        Task<T> GetAsync<T>(string cacheKey);
        bool Add<T>(string cacheKey, T data);
        Task<bool> AddAsync<T>(string cacheKey, T data);
        bool Remove(string cacheKey);
        Task<bool> RemoveAsync(string cacheKey);
    }
}
