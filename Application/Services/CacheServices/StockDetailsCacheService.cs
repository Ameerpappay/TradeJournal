using Application.Dtos;
using Application.IRepositories;
using Application.IServices.ICacheServices;

namespace Application.Services.CacheServices
{
    public class StockDetailsCacheService : IStocksDetailsCacheService
    {
        public readonly ICacheService<List<GetStockDetailsDto>> _cacheService;

        public readonly IStocksDetailsRepository _stocksDetailsRepository;

        const string _cacheKey = "CACHESTOCKDETAILS";

        public StockDetailsCacheService(ICacheService<List<GetStockDetailsDto>> cacheService, IStocksDetailsRepository stocksDetailsRepository)
        {
            _cacheService = cacheService;
            _stocksDetailsRepository = stocksDetailsRepository;
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetails()
        {
            var cacheValue = _cacheService.GetValueFromCache(_cacheKey);

            if (cacheValue != null) return cacheValue;

            await SetStocksDetailsToCache();

            return _cacheService.GetValueFromCache(_cacheKey);
        }

        private async Task SetStocksDetailsToCache()
        {
            var stocksDetails = await _stocksDetailsRepository.GetStocksDetails();
            _cacheService.AddToCache(_cacheKey, stocksDetails);
        }
    }
}
