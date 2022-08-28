
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Core.Cache
{
    public class CacheManager<T> : ICacheManager<T> where T : class
    {
        private readonly IMemoryCache _memoryCache;
        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string cacheKey)
        {
            if (_memoryCache.Get<T>(cacheKey) != null)
            {
                return _memoryCache.Get<T>(cacheKey);
            }
            return default;
        }

        public async Task<T> GetAsync<T>(string cacheKey) 
        {
            if (_memoryCache.Get<T>(cacheKey) != null)
            {
                return await Task.Run(() => _memoryCache.Get<T>(cacheKey));
            }
            return default;
        }

        public bool Add<T>(string cacheKey, T data)
        {
            try
            {
                _memoryCache.Set(cacheKey, data);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddAsync<T>(string cacheKey, T data)
        {
            try
            {
                await Task.Run(() => _memoryCache.Set(cacheKey, data));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Remove(string cacheKey)
        {
            try
            {
                _memoryCache.Remove(cacheKey);                
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<bool> RemoveAsync(string cacheKey)
        {
            try
            {
                await Task.Run(() => _memoryCache.Remove(cacheKey));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
