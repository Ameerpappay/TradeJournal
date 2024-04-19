using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IHoldingsRepository:IGenericRepository<Holding>
    {
        public Task< Holding> GetExistingHolding(string code, int portfolioId);

    }
}
