using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;

namespace MetroBlog.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            app.UseServices(services =>
            {
                services.AddMvc();

                var documentDbOptions = new Domain.DocumentDbOptions()
                {
                    EndpointUrl = configuration.Get("Data:DocumentDB:EndpointUrl"),
                    AuthorizationKey = configuration.Get("Data:DocumentDB:AuthorizationKey"),
                    DatabaseId = configuration.Get("Data:DocumentDB:DatabaseId")
                };

                services.AddInstance<Domain.DocumentDbOptions>(documentDbOptions);
            });

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller=Post}/{action=Index}/{id?}");
            });
        }
    }
}
