using Application.Dtos.Portfolio;

namespace Application.IServices
{
    public interface IPortfolioServices
    {
        Task<List<GetPortfolioDto>> GetPortfolio(string userId);

        Task<GetPortfolioDto> AddPortfolio(AddPortfolioDto portfolio, string UserId);

        Task<GetPortfolioDto> GetPortfolioById(string portfolioId, string userId);

        Task<int> GetPortfolioId(string portfolioId, string userId);

        Task<GetPortfolioDto> GetSelectedPortfolioId(string userId);

        Task<string> SetSelectedPortfolioId(string userId, string porffolioId);

        Task UpdatePortfolio(string Id, UpdatePortfolioDto updatePortfolioDto, string userId);

        Task DeletePortfolioById(string portfolioId, string userId);
    }
}
