using Application.Dtos;

namespace Application.IServices.ICacheServices
{
    public interface IStocksDetailsCacheService
    {
        Task<List<GetStockDetailsDto>> GetStocksDetails();
    }
}
