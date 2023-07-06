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
        Task<List<GetTradeDto>> GetTrades();

        Task<GetTradeDto> AddTrade(AddTradeDto trade);

        Task<GetTradeDto> GetTradeById(int tradeId);

        Task UpdateTrade(int Id, UpdateTradeDto updateTradeDto);

        Task DeleteTradeById(int tradeId);
    }
}
