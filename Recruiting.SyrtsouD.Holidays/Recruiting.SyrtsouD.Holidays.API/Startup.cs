using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruiting.SyrtsouD.Holidays.API.Factories;
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

			services.AddTransient<IHolidayService, HolidayService>();
			services.AddTransient<IHolidayCriteriaFactory, HolidayCriteriaFactory>();
			services.AddTransient<IHolidayResponseFactory, HolidayResponseFactory>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}
