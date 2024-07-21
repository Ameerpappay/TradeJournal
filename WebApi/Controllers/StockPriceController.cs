using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]

    public class StockPriceController : ControllerBase
    {
        private IStockDetailsService _StockPriceManager;
        public StockPriceController(IStockDetailsService stockPriceManager)
        {
            _StockPriceManager = stockPriceManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetStockPrice(string code)
        {
            var response = _StockPriceManager.GetStockDetails(code);
            return Ok(response);
        }
    }
}
