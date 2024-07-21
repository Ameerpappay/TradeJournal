using Application.Dtos;

namespace Application.IServices
{
    public interface IStockDetailsService
    {
        Task<GetStockDetailsDto> GetStockDetails(string stockCode);

        Task<List<GetStockDetailsDto>> GetStocksDetails(List<string> stockCodes);
    }
}
