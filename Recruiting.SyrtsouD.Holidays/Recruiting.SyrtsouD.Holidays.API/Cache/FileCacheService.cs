using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Recruiting.SyrtsouD.Holidays.API.Cache
{
	public class FileCacheService : ICacheService
	{
		private static readonly string FolderName =  $"{AppDomain.CurrentDomain.BaseDirectory}/_cache";

		private readonly TimeSpan _expiration;

		public FileCacheService(TimeSpan expiration)
		{
			_expiration = expiration;
		}

		public bool TryGet<T>(string key, out T cached)
		{
			var result = false;
			cached = default(T);

			var fileName = GetFilePath(key);

			if (File.Exists(fileName))
			{
				if (DateTime.UtcNow - File.GetCreationTimeUtc(fileName) >= _expiration)
				{
					File.Delete(fileName);
				}
				else
				{
					var content = File.ReadAllText(fileName);

					cached = JsonConvert.DeserializeObject<T>(content);
					result = true;
				}
			}

			return result;
		}

		public void AddOrUpdate(string key, object value)
		{
			var fileName = GetFilePath(key);

			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}

			Directory.CreateDirectory(FolderName);

			using (var writer = File.CreateText(fileName))
			{
				var json = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				});

				var sb = new StringBuilder(json);

				writer.Write(sb);
			}
		}

		protected internal virtual string GetFilePath(string key)
		{
			var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
			var regex = new Regex($"[{Regex.Escape(regexSearch)}]");
			var fileName = regex.Replace(key, "_");

			return $"{FolderName}/{fileName}";
		}
	}
}