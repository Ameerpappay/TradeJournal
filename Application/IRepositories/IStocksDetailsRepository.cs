using Application.Dtos;

namespace Application.IRepositories
{
    public interface IStocksDetailsRepository
    {
        Task<List<GetStockDetailsDto>> GetStocksDetails();
    }
}
