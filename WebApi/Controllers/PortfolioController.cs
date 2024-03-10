using Application.Dtos.Strategy;
using Application.Dtos;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Portfolio;
using Application.Dtos.Trade;

namespace WebApi.Controllers
{
    [Route("api/Portfolio")]
    [ApiController]
    //[Authorize(Roles = "Admin,Trader")]
    public class PortfolioController : ControllerBase
    {
        private IPortfolioServices _portfolioServices;

        public PortfolioController(IPortfolioServices portfolioServices)
        {
            _portfolioServices = portfolioServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPortfolioDto>>> GetAll()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            var response = await _portfolioServices.GetPortfolio(userId);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPortfolioDto>> Get(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            return Ok(await _portfolioServices.GetPortfolioById(id, userId));
        }     

        [HttpPost]
        public async Task<ActionResult<GetPortfolioDto>> Add(AddPortfolioDto requestBody)
        {
            return Ok(await _portfolioServices.AddPortfolio(requestBody));
        }


        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdatePortfolioDto requestBody)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            await _portfolioServices.UpdatePortfolio(id, requestBody,userId);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "userIdentifier")?.Value;
            await _portfolioServices.DeletePortfolioById(id,userId);
        }
    }
}
