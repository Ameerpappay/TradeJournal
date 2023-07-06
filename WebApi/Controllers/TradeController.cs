using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/trade")]
    [ApiController]
    public class TradeController: ControllerBase
    {
        private ITradeServices _services;

        public TradeController(ITradeServices tradeService)
        {
            _services = tradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTradeDto>>> GetAll()
        {
            var response = await _services.GetTrades();
            return Ok(response);
        }

        // GET api/<TradeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTradeDto>> Get(int id)
        {
            return Ok(await _services.GetTradeById(id));
        }

        // POST api/<TradeController>
        [HttpPost]
        public async Task<ActionResult<GetTradeDto>> Add(AddTradeDto requestBody)
        {
            return Ok(await _services.AddTrade(requestBody));
        }

        // PUT api/<TradeController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateTradeDto requestBody)
        {
            await _services.UpdateTrade(id, requestBody);
        }

        // DELETE api/<StrategyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _services.DeleteTradeById(id);
        }
    }
}
