using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Owin;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
               .AddTestUsers(new List<IdentityServer4.Test.TestUser>())
               .AddDeveloperSigningCredential();
        }

        public void Configuration(IApplicationBuilder app)
        {

            app.UseIdentityServer();
               
        }
    }
}
