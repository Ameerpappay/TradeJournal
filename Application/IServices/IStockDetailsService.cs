using Application.Dtos;

namespace Application.IServices
{
    public interface IStockDetailsService
    {
        Task<GetStockDetailsDto> GetStockDetails(string stockCode);

        Task<bool> GetStocksDetailsIntoCache();
        Task<List<GetStockDetailsDto>> GetStocksDetailsFromCache();

    }
}
