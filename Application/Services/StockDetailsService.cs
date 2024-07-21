using Application.Dtos;
using Application.IRepositories;
using Application.IServices;

namespace Application.Services
{
    public class StockDetailsService : IStockDetailsService
    {
        IStocksDetailsRepository _stockDetailsRepository;
        public StockDetailsService(IStocksDetailsRepository stocksDetailsRepository)
        {
            _stockDetailsRepository = stocksDetailsRepository;
        }

        public async Task<GetStockDetailsDto> GetStockDetails(string stockCode)
        {
            var stockDetails = await _stockDetailsRepository.GetStockDetails(stockCode);

            return stockDetails;
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetails(List<string> stockCodes)
        {
            var stocksDetails = await _stockDetailsRepository.GetStocksDetails(stockCodes);

            return stocksDetails;
        }
    }
}
