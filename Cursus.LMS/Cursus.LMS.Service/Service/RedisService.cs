using Cursus.LMS.Service.IService;
using StackExchange.Redis;

namespace Cursus.LMS.Service.Service;

public class RedisService : IRedisService
{
    private readonly IConnectionMultiplexer _redis;

    public RedisService(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    /// <summary>
    /// This method for upload data to redis cloud
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public async Task<bool> StoreString(string key, string value)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.StringSetAsync(key, value);
        return result;
    }

    /// <summary>
    /// This method for get data from redis cloud
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async Task<string> RetrieveString(string key)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.StringGetAsync(key);
        return result;
    }

    /// <summary>
    /// This method for delete data from redis cloud
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public async Task<bool> DeleteString(string key)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.KeyDeleteAsync(key);
        return result;
    }
}