using Application.IServices;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]

    public class StockPriceController: ControllerBase
    {
        private IStockPriceManager _StockPriceManager;
        public StockPriceController( IStockPriceManager stockPriceManager)
        {
            _StockPriceManager = stockPriceManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetStockPrice(string code)
        {
            object response =  _StockPriceManager.GetStockPrice(code);
            return Ok(response);
        }
    }
}
