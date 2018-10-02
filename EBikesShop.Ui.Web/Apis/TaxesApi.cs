using EBikesShop.Shared.Taxes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikesShop.Ui.Web.Apis
{
    public class TaxesApi
    {
        public async Task<List<StateTaxDto>> GetStateTaxesAsync()
        {
            await Task.Delay(1000); // simulate API call _httpClient.GetAsync(...);

            return new List<StateTaxDto>
            {
                new StateTaxDto{ StateCode = "UT", StateName="Utah", TaxRate = 6.85m },
                new StateTaxDto{ StateCode = "NV", StateName="Nevada", TaxRate = 8.00m },
                new StateTaxDto{ StateCode = "TX", StateName="Texaas", TaxRate = 6.25m },
                new StateTaxDto{ StateCode = "AL", StateName="Alabama", TaxRate = 4.00m },
                new StateTaxDto{ StateCode = "CA", StateName="California", TaxRate = 8.25m },
            };
        }

        public async Task<List<RetailTaxDto>> GetRetailTaxesAsync()
        {
            await Task.Delay(500); // simulate API call _httpClient.GetAsync(...);

            return new List<RetailTaxDto>
            {
                new RetailTaxDto{ StateCode = "UT", TaxRate = 6.85m },
                new RetailTaxDto{ StateCode = "NV", TaxRate = 8.00m },
                new RetailTaxDto{ StateCode = "TX", TaxRate = 6.25m },
                new RetailTaxDto{ StateCode = "AL", TaxRate = 4.00m },
                new RetailTaxDto{ StateCode = "CA", TaxRate = 8.25m },
            };
        }
    }
}
