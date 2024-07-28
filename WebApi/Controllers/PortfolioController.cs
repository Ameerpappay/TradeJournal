using Application.Dtos.Portfolio;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [Route("api/portfolio-management")]
    [ApiController]
    [Authorize(Roles = "Admin,Trader")]
    public class PortfolioController : ControllerBase
    {
        private IPortfolioServices _portfolioServices;

        public PortfolioController(IPortfolioServices portfolioServices)
        {
            _portfolioServices = portfolioServices;
        }

        [HttpGet("portfolios")]
        public async Task<ActionResult<IEnumerable<GetPortfolioDto>>> GetAll()
        {
            var userId = User.GetUserId();
            var response = await _portfolioServices.GetPortfolio(userId);
            return Ok(response);
        }

        [HttpGet("portfolios/selected-portfolio")]
        public async Task<ActionResult> GetSelectedPortfolioId()
        {
            var userId = User.GetUserId();
            var response = await _portfolioServices.GetSelectedPortfolioId(userId);
            return Ok(response);
        }

        [HttpPut("portfolios/{portfolioId}/selected-portfolio")]
        public async Task<ActionResult> SetSelectedPortfolioId(string portfolioId)
        {
            var userId = User.GetUserId();
            var response = await _portfolioServices.SetSelectedPortfolioId(userId, portfolioId);
            return Ok(response);
        }

        [HttpGet("portfolios/{id}")]
        public async Task<ActionResult<GetPortfolioDto>> Get(string id)
        {
            var userId = User.GetUserId();
            return Ok(await _portfolioServices.GetPortfolioById(id, userId));
        }

        [HttpPost("portfolios")]
        public async Task<ActionResult<GetPortfolioDto>> Add(AddPortfolioDto requestBody)
        {
            var userId = User.GetUserId();
            return Ok(await _portfolioServices.AddPortfolio(requestBody, userId));
        }

        [HttpPut("portfolios/{id}")]
        public async Task Update(string id, [FromBody] UpdatePortfolioDto requestBody)
        {
            var userId = User.GetUserId();
            await _portfolioServices.UpdatePortfolio(id, requestBody, userId);
        }

        [HttpDelete("portfolios/{id}")]
        public async Task Delete(string id)
        {
            var userId = User.GetUserId();
            await _portfolioServices.DeletePortfolioById(id, userId);
        }
    }
}
