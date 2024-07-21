using Domain.Entities;

namespace Application.IRepositories
{
    public interface IHoldingsRepository : IGenericRepository<Holding>
    {
        public Task<Holding> GetExistingHolding(string code, int portfolioId);

        public Task<IEnumerable<Holding>> Get(string userId, int portfolioId);

    }
}
