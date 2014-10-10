namespace MetroBlog.vNext
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Routing;
    using Microsoft.Framework.DependencyInjection;

    public class Startup
    {
        public void Configure(IBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Default", template: "{controller=Post}/{action=Index}/{id?}");
            });
        }
    }
}
