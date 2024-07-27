using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]

    public class StockPriceController : ControllerBase
    {
        private IStockDetailsService _stockDetailsService;
        public StockPriceController(IStockDetailsService stockDetailsService)
        {
            _stockDetailsService = stockDetailsService;
        }

        [HttpGet("Code")]
        public async Task<ActionResult> GetStockPrice(string code)
        {
            var response = await _stockDetailsService.GetStockDetails(code);



            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetStockPriceList()
        {
            var response = await _stockDetailsService.GetStocksDetailsFromCache();
            return Ok(response);
        }
    }
}
