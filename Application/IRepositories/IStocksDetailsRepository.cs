using Application.Dtos;

namespace Application.IRepositories
{
    public interface IStocksDetailsRepository
    {
        Task<GetStockDetailsDto> GetStockDetails(string code);

        Task<List<GetStockDetailsDto>> GetStocksDetails(List<string> stockCodes);

    }
}
