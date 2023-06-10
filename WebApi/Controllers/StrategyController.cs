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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StrategyController>
        [HttpPost]
        public async Task<ActionResult<GetStrategyDto>> Add(AddStrategyDto requestBody )
        {
            return Ok(await _strategyService.AddStrategy(requestBody));
        }

        // PUT api/<StrategyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StrategyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _strategyService.DeleteStrategyById(id);
        }
    }
}
