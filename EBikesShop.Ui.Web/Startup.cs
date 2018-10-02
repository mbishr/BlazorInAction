using EBikesShop.Ui.Web.Apis;
using EBikesShop.Ui.Web.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EBikesShop.Ui.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TaxesApi>();
            services.AddSingleton<RetailCalculator>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
