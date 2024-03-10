using Application.Dtos;
using Application.Dtos.Strategy;
using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StrategyService : IStrategyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StrategyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStrategyDto> AddStrategy(AddStrategyDto strategy,string addedBy)
        {
            var newStrategy = new Strategy()
            {
                Name = strategy.Name,
                Description = strategy.Description,
                CreatedByUserId = addedBy,
            };

            var addedStrategy = await _unitOfWork.StrategyRepository.Add(newStrategy);
            await _unitOfWork.SaveChangesAsync();

            return new GetStrategyDto()
            {
                Description = addedStrategy.Description,
                Name = addedStrategy.Name,
                Id = addedStrategy.Identifier.ToString(),
            };
        }

        public async Task DeleteStrategyById(int strategyId, string userId)
        {
            await _unitOfWork.StrategyRepository.Delete(strategyId,userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetStrategyDto>> GetStrategies(string userId)
        {
            var result = await _unitOfWork.StrategyRepository.Get(userId);
            var strategies = result.Select(s => new GetStrategyDto
            {
                Id = s.Identifier.ToString(),
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return strategies;
        }

        public async Task<GetStrategyDto> GetStrategyById(int strategyId, string userId)
        {
            var result = await _unitOfWork.StrategyRepository.Get(strategyId,userId);
            var strategy = new GetStrategyDto();
            strategy.Id = result.Identifier.ToString();
            strategy.Name = result.Name;
            strategy.Description = result.Description;
            return strategy;
        }

        public async Task UpdateStrategy(int Id, UpdateStrategyDto strategy, string userId)
        {
            var result = await _unitOfWork.StrategyRepository.Get(Id, userId);
            result.Description = strategy.Description;
            result.Name = strategy.Name;

            await _unitOfWork.StrategyRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
