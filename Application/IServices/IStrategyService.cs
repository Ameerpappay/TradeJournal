using Application.Dtos;
using Application.Dtos.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IStrategyService
    {
        Task<List<GetStrategyDto>> GetStrategies();

        Task<GetStrategyDto> AddStrategy(AddStrategyDto strategy,string addedBy);

        Task<GetStrategyDto> GetStrategyById(int strategyId);

        Task UpdateStrategy(int Id, UpdateStrategyDto updateStrategyDto);

        Task DeleteStrategyById(int strategyId);
    }
}
