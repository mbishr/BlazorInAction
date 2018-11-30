using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EBikesShop.Shared.Taxes;
using Microsoft.AspNetCore.Mvc;

namespace EBikeShop.Server.Controllers
{
    [Route("api/taxes")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly IDbSession _dbSession;

        public TaxesController(IDbSession dbSession)
        {
            _dbSession = dbSession;
        }

        // GET api/taxes
        [HttpGet]
        public async Task<ActionResult> GetStateTaxes()
        {
            using (var dbConnection = _dbSession.GetConnection())
            {
                var taxes = await dbConnection.QueryAsync<StateTaxDto>("SELECT * FROM state_tax");
                return new JsonResult(taxes.ToList());
            }
        }
    }
}
