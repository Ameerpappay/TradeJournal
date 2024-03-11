using Application.Dtos.Strategy;
using Application.Dtos;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Portfolio;
using Application.Dtos.Trade;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/Portfolio")]
    [ApiController]
    [Authorize(Roles = "Admin,Trader")]
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
            var userId = User.GetUserId();
            var response = await _portfolioServices.GetPortfolio(userId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPortfolioDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _portfolioServices.GetPortfolioById(id, userId));
        }     

        [HttpPost]
        public async Task<ActionResult<GetPortfolioDto>> Add(AddPortfolioDto requestBody)
        {
            var userId = User.GetUserId();
            return Ok(await _portfolioServices.AddPortfolio(requestBody,userId));
        }


        [HttpPut("{id}")]
        public async Task PutAsync(string id, [FromBody] UpdatePortfolioDto requestBody)
        {
            var userId = User.GetUserId();
            await _portfolioServices.UpdatePortfolio(id, requestBody,userId);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var userId = User.GetUserId();
            await _portfolioServices.DeletePortfolioById(id,userId);
        }
    }
}
