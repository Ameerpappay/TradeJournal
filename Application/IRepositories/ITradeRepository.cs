using Application.Dtos.Trade;
using Domain.Entities;

namespace Application.IRepositories
{
    public interface ITradeRepository : IGenericRepository<Trade>
    {
        public Task<IEnumerable<GetTradeDto>> GetTradesByHolidingID(string userId, string holdingId);
        public Task<IEnumerable<Trade>> Get(string createdById, int portfolioId);

    }
}
