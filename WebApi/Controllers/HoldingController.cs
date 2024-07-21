using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/Holding")]
    [ApiController]
    public class HoldingController:ControllerBase
    {
        IHoldingsServices _holdingsServices;
        public HoldingController(IHoldingsServices holdingsServices)
        {
            _holdingsServices = holdingsServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTradeDto>>> GetAll()
        {
            var userId = User.GetUserId();
            var response = await _holdingsServices.GetHoldings(userId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTradeDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _holdingsServices.GetHoldingByID(id, userId));
        }


    }
}
