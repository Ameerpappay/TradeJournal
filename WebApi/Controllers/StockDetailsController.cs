using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/stocks-details-management")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]

    public class StockDetailsController : ControllerBase
    {
        private IStockDetailsService _stockDetailsService;
        public StockDetailsController(IStockDetailsService stockDetailsService)
        {
            _stockDetailsService = stockDetailsService;
        }

        [HttpGet("{code}/stock-details")]
        public async Task<ActionResult> GetStockDetails(string code)
        {
            var response = await _stockDetailsService.GetStockDetails(code);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("stocks-details")]
        public async Task<ActionResult> GetStocksDetails()
        {
            var response = await _stockDetailsService.GetStocksDetails();

            return Ok(response);
        }
    }
}
