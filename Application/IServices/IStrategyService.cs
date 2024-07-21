using Application.Dtos;
using Application.Dtos.Strategy;

namespace Application.IServices
{
    public interface IStrategyService
    {
        Task<List<GetStrategyDto>> GetStrategies(string userId);

        Task<GetStrategyDto> AddStrategy(AddStrategyDto strategy, string addedBy);

        Task<GetStrategyDto> GetStrategyById(string strategyId, string userId);

        Task UpdateStrategy(string Id, UpdateStrategyDto updateStrategyDto, string userId);

        Task DeleteStrategyById(string strategyId, string userId);
        Task<int> GetStrategyId(string identifier, string userId);


    }
}
