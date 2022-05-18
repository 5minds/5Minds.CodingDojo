using Microsoft.Extensions.Caching.Memory;

namespace Recruiting.SyrtsouD.Holidays.API.Cache
{
	public class MemoryCacheService : ICacheService
	{
		private readonly IMemoryCache _memoryCache;

		public MemoryCacheService(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public bool TryGet<T>(string key, out T cached)
		{
			cached = default(T);
			var result = false;

			if (_memoryCache.TryGetValue(key, out var value))
			{
				cached = (T) value;
				result = true;
			}

			return result;
		}

		public void AddOrUpdate(string key, object value)
		{
			_memoryCache.Set(key, value);
		}
	}
}