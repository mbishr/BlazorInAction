using System.Net.Http;
using EBikesShop.Shared;
using EBikesShop.Ui.Web.Apis;
using EBikesShop.Ui.Web.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Blazor.Browser.Http;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EBikesShop.Ui.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();
            services.AddSingleton<TaxesApi>();
            services.AddSingleton<RetailCalculator>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");

            // Sets Blazor's message handler into Flurl, this fixes a Blazor linker problem 
            // https://stackoverflow.com/questions/52522004/blazor-0-6-0-wipes-flurl-compatibility
            FlurlHttp.Configure(settings =>
            {
                settings.HttpClientFactory = new HttpClientFactoryForBlazor();
            });
        }

        private class HttpClientFactoryForBlazor : DefaultHttpClientFactory
        {
            public override HttpMessageHandler CreateMessageHandler()
            {
                return new BrowserHttpMessageHandler();
            }
        }
    }
}
