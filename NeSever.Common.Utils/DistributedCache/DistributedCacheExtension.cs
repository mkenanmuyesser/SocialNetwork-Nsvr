using Microsoft.Extensions.Caching.Distributed;
using NeSever.Common.Utils.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace NeSever.Common.Utils.DistributedCache
{
    public static class DistributedCacheExtension
    {
        public async static Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default(CancellationToken))
        {
            await distributedCache.SetAsync(key, value.ToByteArray(), options, token);
        }

        public async static Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await distributedCache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }
    }
}
