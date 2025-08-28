// 代码生成时间: 2025-08-29 04:53:07
 * This includes error handling, comments for clarity and maintainability,
 * and follows best practices for C# development.
 */

using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;

/// <summary>
/// Cache strategy implementation using .NET MemoryCache.
/// </summary>
public class CacheStrategy
{
    private MemoryCache _cache;

    /// <summary>
    /// Initializes a new instance of the CacheStrategy class.
    /// </summary>
    public CacheStrategy()
    {
        _cache = new MemoryCache("CacheStrategyCache");
    }

    /// <summary>
    /// Retrieves an item from the cache or computes and stores it if not present.
    /// </summary>
    /// <typeparam name="T">The type of the item to cache.</typeparam>
    /// <param name="key">The key under which the item is stored.</param>
    /// <param name="valueFactory">A function to compute the value if not cached.</param>
    /// <returns>The cached item.</returns>
    public T GetOrSet<T>(string key, Func<T> valueFactory)
    {
        try
        {
            // Attempt to retrieve the item from the cache.
            T cachedItem = _cache.Get(key) as T;
            if (cachedItem == null)
            {
                // If not cached, compute and store the item.
                cachedItem = valueFactory();
                _cache.Set(key, cachedItem, new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) // Expire in 1 hour.
                });
            }
            return cachedItem;
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur.
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Removes an item from the cache.
    /// </summary>
    /// <param name="key">The key of the item to remove.</param>
    public void Remove(string key)
    {
        _cache.Remove(key);
    }

    /// <summary>
    /// Clears the entire cache.
    /// </summary>
    public void Clear()
    {
        _cache.Dispose();
    }
}
