using Application.Dtos.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITradeServices
    {
        Task<List<GetTradeDto>> GetTrades(string userId);

        Task<GetTradeDto> AddTrade(AddTradeDto trade,string contentRootPath);

        Task<GetTradeDto> GetTradeById(int tradeId,string userId);

        Task UpdateTrade(int Id, UpdateTradeDto updateTradeDto, string userId);

        Task DeleteTradeById(int tradeId, string userId);
    }
}
