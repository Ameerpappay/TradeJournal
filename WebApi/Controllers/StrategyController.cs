using Application.Dtos;
using Application.Dtos.Strategy;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/strategies")]
    [ApiController]
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

        // GET api/<StrategyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStrategyDto>> Get(int id)
        {
            return Ok(await _strategyService.GetStrategyById(id)) ;
        }

        // POST api/<StrategyController>
        [HttpPost]
        public async Task<ActionResult<GetStrategyDto>> Add(AddStrategyDto requestBody )
        {
            return Ok(await _strategyService.AddStrategy(requestBody));
        }

        // PUT api/<StrategyController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdateStrategyDto requestBody)
        {      
            await _strategyService.UpdateStrategy(id,requestBody);
        }

        // DELETE api/<StrategyController>/5
        [HttpDelete("{id}")]
        public async Task  Delete(int id)
        {
           await  _strategyService.DeleteStrategyById(id);
        }
    }
}
