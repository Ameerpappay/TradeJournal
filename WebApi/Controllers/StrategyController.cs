using Application.Dtos;
using Application.Dtos.Strategy;
using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/strategies")]
    [ApiController]
    [Authorize(Roles = "Admin,Trader")]
    public class StrategyController : ControllerBase
    {
        private IStrategyService _strategyService;
        public StrategyController(IStrategyService strategyService)
        {
            _strategyService = strategyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStrategyDto>>> GetAll()
        {
            var userId = User.GetUserId();
            var response = await _strategyService.GetStrategies(userId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStrategyDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _strategyService.GetStrategyById(id, userId));
        } 

        [HttpPost]
        public async Task<ActionResult<GetStrategyDto>> Add(AddStrategyDto requestBody)
        {
            var userId = User.GetUserId();
            var response = await _strategyService.AddStrategy(requestBody, userId);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] UpdateStrategyDto requestBody)
        {
            var userId = User.GetUserId();
            await _strategyService.UpdateStrategy(id, requestBody,userId);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var userId = User.GetUserId();
            await _strategyService.DeleteStrategyById(id,userId);
        }
    }
}
