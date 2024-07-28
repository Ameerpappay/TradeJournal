using Application.Dtos;
using Application.IRepositories;
using Application.IServices;
using Application.IServices.ICacheServices;

namespace Application.Services
{
    public class StockDetailsService : IStockDetailsService
    {
        private readonly IStocksDetailsRepository _stockDetailsRepository;

        private readonly IStocksDetailsCacheService _stocksDetailsCacheService;

        public StockDetailsService(IStocksDetailsRepository stocksDetailsRepository, IStocksDetailsCacheService stocksDetailsCacheService)
        {
            _stockDetailsRepository = stocksDetailsRepository;
            _stocksDetailsCacheService = stocksDetailsCacheService;
        }

        public async Task<GetStockDetailsDto> GetStockDetails(string stockCode)
        {
            var stocksDetails = await _stocksDetailsCacheService.GetStocksDetails();
            var stock = stocksDetails.FirstOrDefault(s => s.BSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase) || s.NSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase));

            return stock;
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetails()
        {
            var stocksDetails = await _stocksDetailsCacheService.GetStocksDetails();

            return stocksDetails;
        }
    }
}
