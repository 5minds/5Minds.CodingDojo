using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruiting.SyrtsouD.Holidays.API.Cache;
using Recruiting.SyrtsouD.Holidays.API.Clients;
using Recruiting.SyrtsouD.Holidays.API.Factories;
using Recruiting.SyrtsouD.Holidays.API.Resolvers;
using Recruiting.SyrtsouD.Holidays.API.Services;

namespace Recruiting.SyrtsouD.Holidays.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddMemoryCache();

			services.AddTransient<IHolidayService, HolidayService>();
			services.AddTransient<IHolidayCriteriaFactory, HolidayCriteriaFactory>();
			services.AddTransient<IHolidayResponseFactory, HolidayResponseFactory>();
			services.AddTransient<ICalendarificConfigurationsResolver, CalendarificConfigurationsResolver>();
			services.AddSingleton<ICalendarificClient, CalendarificClient>();
			services.AddSingleton<IHolidayFactory, HolidayFactory>();
			services.AddTransient<MemoryCacheService, MemoryCacheService>();
			services.AddTransient<IHolidayCache>(p =>
				new HolidayCache(p.GetService<MemoryCacheService>(), new FileCacheService(TimeSpan.FromDays(1))));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseCors(x => x.AllowAnyOrigin());

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}
