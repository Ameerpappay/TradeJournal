using Application.Dtos.Trade;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/trade-management")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private ITradeServices _services;
        private IImageService _imageService;
        public static IWebHostEnvironment _environment;

        public TradeController(ITradeServices tradeService, IImageService imageService, IWebHostEnvironment environment)
        {
            _services = tradeService;
            _imageService = imageService;
            _environment = environment;
        }

        [HttpGet("trades")]
        public async Task<ActionResult<IEnumerable<GetTradeDto>>> GetAll()
        {
            // var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            var userId = User.GetUserId();

            var response = await _services.GetTrades(userId);
            return Ok(response);
        }

        [HttpGet("trades/{id}")]
        public async Task<ActionResult<GetTradeDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _services.GetTradeById(id, userId));
        }

        [HttpPost("trades")]
        public async Task<ActionResult<GetTradeDto>> Add([FromForm] AddTradeDto requestBody)
        {
            var userId = User.GetUserId();
            return Ok(await _services.AddTrade(requestBody, _environment.ContentRootPath, userId));
        }

        [HttpPut("trades/{id}")]
        public async Task Update(string id, [FromForm] UpdateTradeDto requestBody)
        {
            var userId = User.GetUserId();
            await _services.UpdateTrade(id, requestBody, userId);
        }

        [HttpDelete("trades/{id}")]
        public async Task Delete(string id)
        {
            var userId = User.GetUserId();
            await _services.DeleteTradeById(id, userId);
        }
    }
}
