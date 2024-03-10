using Application.Dtos;
using Application.Dtos.Strategy;
using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/strategies")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]
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
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            var response = await _strategyService.GetStrategies(userId);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetStrategyDto>> Get(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            return Ok(await _strategyService.GetStrategyById(id, userId));
        }
        //public async Task<string> GetAsync(int id)
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;            
        //    //return Ok(await _strategyService.GetStrategyById(id, userId));
        //    return "value";
        //}

        [HttpPost]
        public async Task<ActionResult<GetStrategyDto>> Create(AddStrategyDto requestBody)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            throw new NotImplementedException();
            return Ok(await _strategyService.AddStrategy(requestBody, userId));
        }


        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] UpdateStrategyDto requestBody)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            await _strategyService.UpdateStrategy(id, requestBody,userId);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            await _strategyService.DeleteStrategyById(id,userId);
        }
    }
}
