// 代码生成时间: 2025-10-09 20:36:51
using System;
using System.Collections.Generic;
# NOTE: 重要实现细节
using System.Threading;
# 优化算法效率
using Microsoft.Extensions.Caching.Memory;

namespace CacheStrategy
{
    /// <summary>
    /// CacheStrategy provides a simple caching mechanism.
    /// </summary>
    public class CacheStrategy
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _defaultExpiration;

        /// <summary>
        /// Initializes a new instance of the CacheStrategy class with a default expiration.
        /// </summary>
        /// <param name="defaultExpiration">The default expiration time for cached items.</param>
        public CacheStrategy(TimeSpan defaultExpiration)
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            _defaultExpiration = defaultExpiration;
        }

        /// <summary>
        /// Retrieves a cached item by key, or adds it if it doesn't exist.
        /// </summary>
        /// <typeparam name="T">The type of the cached item.</typeparam>
        /// <param name="key">The unique key for the cached item.</param>
        /// <param name="valueFactory">A delegate that creates the value if it doesn't exist in the cache.</param>
        /// <returns>The cached item.</returns>
# TODO: 优化性能
        public T GetOrCreate<T>(object key, Func<T> valueFactory)
        {
# NOTE: 重要实现细节
            if (_cache.TryGetValue(key, out T value))
            {
# 改进用户体验
                return value;
            }
            else
            {
                value = valueFactory();
                _cache.Set(key, value, _defaultExpiration);
                return value;
            }
# TODO: 优化性能
        }

        /// <summary>
        /// Removes an item from the cache by key.
        /// </summary>
        /// <param name="key">The unique key for the item to remove.</param>
# 添加错误处理
        public void Remove(object key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Clears all items from the cache.
        /// </summary>
        public void Clear()
        {
            _cache.Clear();
        }
    }
}
