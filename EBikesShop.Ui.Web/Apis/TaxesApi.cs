using EBikesShop.Shared;
using EBikesShop.Shared.Taxes;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikesShop.Ui.Web.Apis
{
    // Linker needs to be disabled for the moment in order to be able to desertize json with NewtonJson/Flurl
    // https://github.com/aspnet/Blazor/issues/370
    public class TaxesApi
    {
        private AppSettings _settings;

        public TaxesApi(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task<IList<StateTaxDto>> GetStateTaxesAsync()
        {
            return await _settings.ApiBaseUrl
                .AppendPathSegment("taxes")
                .WithHeader("Accept", "application/json")
                .GetJsonAsync<List<StateTaxDto>>();
        }

        public Task CreateStateTaxAsync(StateTaxDto stateTax)
        {
            throw new NotImplementedException();
        }
    }
}
