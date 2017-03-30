namespace DotnetHello
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());
            app.UseMvc();
        }
    }
}