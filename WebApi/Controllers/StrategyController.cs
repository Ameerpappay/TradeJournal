using Application.Dtos;
using Application.Dtos.Strategy;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/strategies")]
    [ApiController]
    [Authorize(Roles ="Admin,Trader")]
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
        public async Task<ActionResult<GetStrategyDto>> Add(AddStrategyDto requestBody )
        {
            return Ok(await _strategyService.AddStrategy(requestBody));
        }


        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateStrategyDto requestBody)
        {      
            await _strategyService.UpdateStrategy(id,requestBody);
        }


        [HttpDelete("{id}")]
        public async Task  Delete(int id)
        {
           await  _strategyService.DeleteStrategyById(id);
        }
    }
}
