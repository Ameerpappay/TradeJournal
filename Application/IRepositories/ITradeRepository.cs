using Application.Dtos.Trade;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ITradeRepository:IGenericRepository<Trade>
    {
        public Task<IEnumerable<GetTradeDto>> GetTradesByHolidingID(string userId, string holdingId);
        public Task<IEnumerable<Trade>> Get(string createdById, int portfolioId);

    }
}
