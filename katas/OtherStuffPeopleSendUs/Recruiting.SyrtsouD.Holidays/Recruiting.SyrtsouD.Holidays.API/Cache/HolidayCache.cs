using System;
using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Cache
{
	public class HolidayCache : IHolidayCache
	{
		private readonly ICacheService _memoryCache;
		private readonly ICacheService _fileService;

		public HolidayCache(ICacheService memoryCache, ICacheService fileService)
		{
			_memoryCache = memoryCache;
			_fileService = fileService;
		}

		public bool TryGet(IHolidayCriteria criteria, out IReadOnlyCollection<IHoliday> holidays)
		{
			var key = GetCacheKey(criteria);
			holidays = Array.Empty<IHoliday>();
			var result = false;

			if (_memoryCache.TryGet<IReadOnlyCollection<IHoliday>>(key, out var cached))
			{
				holidays = cached;
				result = true;
			}
			else
			{
				if (_fileService.TryGet(key, out cached))
				{
					holidays = cached;
					result = true;
				}
			}

			return result;
		}

		public void AddOrUpdate(IHolidayCriteria criteria, IReadOnlyCollection<IHoliday> holidays)
		{
			var key = GetCacheKey(criteria);

			_memoryCache.AddOrUpdate(key, holidays);
			_fileService.AddOrUpdate(key, holidays);
		}

		protected internal virtual string GetCacheKey(IHolidayCriteria criteria)
		{
			return $"HolidayCache::{criteria.CountryCode}::{criteria.Year}";
		}
	}
}