namespace Recruiting.SyrtsouD.Holidays.API.Cache
{
	public interface ICacheService
	{
		bool TryGet<T>(string key, out T cached);

		void AddOrUpdate(string key, object value);
	}
}