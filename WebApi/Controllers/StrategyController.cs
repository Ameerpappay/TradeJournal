using Application.Dtos;
using Application.Dtos.Strategy;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var response = await _strategyService.GetStrategies();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<GetStrategyDto>> Create(AddStrategyDto requestBody)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;

            return Ok(await _strategyService.AddStrategy(requestBody, userId));
        }


        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateStrategyDto requestBody)
        {
            await _strategyService.UpdateStrategy(id, requestBody);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _strategyService.DeleteStrategyById(id);
        }
    }
}
