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

        Task<GetStrategyDto > AddStrategy(AddStrategyDto strategy);

       Task<GetStrategyDto> GetStrategyById(int strategyId);
        Task<GetStrategyDto> UpdateStrategyById(int strategyId);
        DeleteStrategyById(int strategyId);
    }
}
