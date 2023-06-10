﻿using Application.Dtos;
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
        public void Post([FromBody] string value)
        {
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
        }
    }
}
