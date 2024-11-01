
using App.Application.Interfaces.Caching;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace App.Infrastructure.Persistence.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase? _redisDb;

        public RedisCacheService(IConnectionMultiplexer? connectionMultiplexer)
        {
            _redisDb = connectionMultiplexer.GetDatabase();

        }
        public async Task<T?> GetData<T>(string key)
        {
            var data = await _redisDb.StringGetAsync(key);

            if (data.IsNullOrEmpty)
                return default(T);

            return JsonSerializer.Deserialize<T>(data);
        }

        public void SetData<T>(string key, T data)
        {
            //var options = new DistributedCacheEntryOptions()
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            //};
            _redisDb?.StringSetAsync(key, JsonSerializer.Serialize(data));
        }
    }
}
