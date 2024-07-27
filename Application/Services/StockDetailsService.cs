using Application.Dtos;
using Application.IRepositories;
using Application.IServices;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Application.Services
{
    public class StockDetailsService : IStockDetailsService
    {
        IStocksDetailsRepository _stockDetailsRepository;
        private readonly IMemoryCache _cache;


        public StockDetailsService(IStocksDetailsRepository stocksDetailsRepository, IMemoryCache memoryCache)
        {
            _stockDetailsRepository = stocksDetailsRepository;
            _cache = memoryCache;
        }

        public async Task<GetStockDetailsDto> GetStockDetails(string stockCode)
        {
            if (_cache.TryGetValue("stocksList", out List<GetStockDetailsDto> stocksList))
            {
                var stock = stocksList.FirstOrDefault(s =>  s.BSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase)|| s.NSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase));
                return stock;
            }
            else
            {
                await GetStocksDetailsIntoCache();
                if (_cache.TryGetValue("stocksList", out List<GetStockDetailsDto> stockList))
                {
                    var stock = stockList.FirstOrDefault(s => s.BSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase) || s.NSECode.Equals(stockCode, StringComparison.OrdinalIgnoreCase));
                    return stock;
                }
                return null;
            }
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetailsFromCache()
        {
            if (_cache != null)
            {
                await GetStocksDetailsIntoCache();

                if (_cache.TryGetValue("stocksList", out List<GetStockDetailsDto> stocksList))
                {
                    return stocksList;
                }
            }
            else
            {
                GetStocksDetailsIntoCache();
                if (_cache.TryGetValue("stocksList", out List<GetStockDetailsDto> stocksList))
                {
                    return stocksList;
                }            
            }
            return null;
        }

        public async Task<bool> GetStocksDetailsIntoCache()
        {
            string cacheKey = "GoogleSheetData_FullSheet";
            try
            {
                var stocksDetails = await _stockDetailsRepository.GetStocksDetails();
                _cache.Set("stocksList", stocksDetails, TimeSpan.FromMinutes(10));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Forbidden access to the Google Sheets API. Ensure proper permissions and credentials.");
                return false;
            }
        }
    }
}
