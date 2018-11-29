using System.Collections.Generic;
using System.Threading;
using EBikesShop.Shared.Taxes;
using Microsoft.AspNetCore.Mvc;

namespace EBikeShop.Server.Controllers
{
    [Route("api/taxes")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private static readonly IList<StateTaxDto> _taxes = new List<StateTaxDto>
        {
            new StateTaxDto{ StateCode = "UT", StateName="Utah", TaxRate = 6.85m },
            new StateTaxDto{ StateCode = "NV", StateName="Nevada", TaxRate = 8.00m },
            new StateTaxDto{ StateCode = "TX", StateName="Texas", TaxRate = 6.25m },
            new StateTaxDto{ StateCode = "AL", StateName="Alabama", TaxRate = 4.00m },
            new StateTaxDto{ StateCode = "CA", StateName="California", TaxRate = 8.25m },
        };

        // GET api/taxes
        [HttpGet]
        public ActionResult GetStateTaxes()
        {
            return new JsonResult(_taxes);
        }
    }
}
