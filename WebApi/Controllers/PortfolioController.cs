using Application.Dtos.Strategy;
using Application.Dtos;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Portfolio;

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
            var response = await _portfolioServices.GetPortfolio();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<GetPortfolioDto>> Add(AddPortfolioDto requestBody)
        {
            return Ok(await _portfolioServices.AddPortfolio(requestBody));
        }


        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UpdatePortfolioDto requestBody)
        {
            await _portfolioServices.UpdatePortfolio(id, requestBody);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _portfolioServices.DeletePortfolioById(id);
        }
    }
}
