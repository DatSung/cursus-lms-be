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

    public async Task<bool> Store(string key, string value)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.StringSetAsync(key, value);
        return result;
    }

    public async Task<string> Retrieve(string key)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.StringGetAsync(key);
        return result;
    }

    public async Task<bool> Delete(string key)
    {
        var cache = _redis.GetDatabase();
        var result = await cache.KeyDeleteAsync(key);
        return result;
    }
}