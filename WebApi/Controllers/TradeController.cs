using Application.Dtos.Image;
using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<GetTradeDto>> Add([FromForm]AddTradeDto requestBody)
        {
            //var response = await _imageService.AddImage(AddImageDto);
            return Ok(await _services.AddTrade(requestBody,_environment.ContentRootPath));
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
