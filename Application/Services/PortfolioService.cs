using Application.Dtos.Portfolio;
using Application.IServices;
using Domain.Entities;

namespace Application.Services
{
    public class PortfolioService : IPortfolioServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PortfolioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPortfolioDto> AddPortfolio(AddPortfolioDto portfolio, string addedBy)
        {

            var newPortfolio = new Portfolio()
            {
                Description = portfolio.Description,
                Name = portfolio.Name,
                CreatedByUserId = addedBy,
                IsDeleted = false,
            };
            GetPortfolioDto selectedPortfolio = await _unitOfWork.PortfolioRepository.SelectedPortfolio(addedBy);
            if (selectedPortfolio == null)
            {
                newPortfolio.IsSelected = true;
            }

            var addedPortfolio = await _unitOfWork.PortfolioRepository.Add(newPortfolio);
            await _unitOfWork.SaveChangesAsync();
            return new GetPortfolioDto()
            {
                Description = addedPortfolio.Description,
                Name = addedPortfolio.Name,
                Identifier = addedPortfolio.Identifier.ToString()
            };
        }

        public async Task DeletePortfolioById(string portfolioId, string userId)
        {
            await _unitOfWork.PortfolioRepository.Delete(portfolioId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetPortfolioDto>> GetPortfolio(string userId)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(userId);
            var portfolio = result.Select(s => new GetPortfolioDto
            {
                Identifier = s.Identifier.ToString(),
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return portfolio;
        }

        public async Task<GetPortfolioDto> GetPortfolioById(string portfolioId, string userId)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(portfolioId, userId);
            var portfolio = new GetPortfolioDto();
            portfolio.Identifier = result.Identifier.ToString();
            portfolio.Name = result.Name;
            portfolio.Description = result.Description;
            return portfolio;
        }

        public async Task<int> GetPortfolioId(string portfolioId, string userId)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(portfolioId, userId);
            return result.Id;
        }

        public async Task<GetPortfolioDto> GetSelectedPortfolioId(string userId)
        {
            var result = await _unitOfWork.PortfolioRepository.SelectedPortfolio(userId);
            return result;
        }

        public Task<string> SetSelectedPortfolioId(string userId, string porffolioId)
        {
            _unitOfWork.PortfolioRepository.SetSelectedPortfolio(userId, porffolioId);
            return Task.FromResult("success");
        }

        public async Task UpdatePortfolio(string Id, UpdatePortfolioDto updatePortfolioDto, string userId)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(Id, userId);
            result.Description = updatePortfolioDto.Description;
            result.Name = updatePortfolioDto.Name;

            _unitOfWork.PortfolioRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
