using Application.Dtos.Trade;

namespace Application.IServices
{
    public interface ITradeServices
    {
        Task<List<GetTradeDto>> GetTrades(string userId);

        Task<GetTradeDto> AddTrade(AddTradeDto trade, string contentRootPath, string userId);

        Task<GetTradeDto> GetTradeById(string tradeId, string userId);

        Task UpdateTrade(string tradeId, UpdateTradeDto updateTradeDto, string userId);

        Task DeleteTradeById(string tradeId, string userId);
        Task<List<GetTradeDto>> GetTradesByHolidingID(string userId, string holdingId);

    }
}
