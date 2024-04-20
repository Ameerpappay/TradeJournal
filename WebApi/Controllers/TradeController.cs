using Application.Dtos.Image;
using Application.Dtos.Trade;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/Trade")]
    [ApiController]
    public class TradeController: ControllerBase
    {
        private ITradeServices _services;
        private IImageService _imageService;
        public static IWebHostEnvironment _environment;

        public TradeController(ITradeServices tradeService,IImageService imageService, IWebHostEnvironment environment)
        {
            _services = tradeService;
            _imageService = imageService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTradeDto>>> GetAll()
        {
            // var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            var userId = User.GetUserId();

            var response = await _services.GetTrades(userId);
            return Ok(response);
        }

        // GET api/<TradeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTradeDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _services.GetTradeById(id,userId));
        }

        // POST api/<TradeController>
        [HttpPost]
        public async Task<ActionResult<GetTradeDto>> Add([FromForm]AddTradeDto requestBody)
        {
            var userId = User.GetUserId();
            //var response = await _imageService.AddImage(AddImageDto);
            return Ok(await _services.AddTrade(requestBody,_environment.ContentRootPath,userId));
        }

        // PUT api/<TradeController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(string id, [FromBody] UpdateTradeDto requestBody)
        {
            var userId = User.GetUserId();
            await _services.UpdateTrade(id, requestBody,userId);
        }

        // DELETE api/<StrategyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var userId = User.GetUserId();
            await _services.DeleteTradeById(id,userId);
        }
    }
}
