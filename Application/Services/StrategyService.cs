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

        public async Task<GetStrategyDto> AddStrategy(AddStrategyDto strategy)
        {
            var newStrategy = new Strategy()
            {
                Name = strategy.Name,
                Description = strategy.Description,
            };
            var addedStrategy = await _unitOfWork.StrategyRepository.Add(newStrategy);
            await _unitOfWork.SaveChangesAsync();
            return new GetStrategyDto()
            {
                Description = addedStrategy.Description,
                Name = addedStrategy.Name,
                Id = addedStrategy.Id
            };
        }

        public async Task DeleteStrategyById(int strategyId)
        {
            await _unitOfWork.StrategyRepository.Delete(strategyId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetStrategyDto>> GetStrategies()
        {
            var result = await _unitOfWork.StrategyRepository.Get();
            var strategies = result.Select(s => new GetStrategyDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return strategies;
        }

        public async Task<GetStrategyDto> GetStrategyById(int strategyId)
        {
            var result = await _unitOfWork.StrategyRepository.Get(strategyId);
            var strategy = new GetStrategyDto();
            strategy.Id = result.Id;
            strategy.Name = result.Name;
            strategy.Description = result.Description;
            return strategy;
        }

        public async Task UpdateStrategy(int Id, UpdateStrategyDto strategy)
        {
            var result = await _unitOfWork.StrategyRepository.Get(Id);
            result.Description = strategy.Description;
            result.Name = strategy.Name;

            await _unitOfWork.StrategyRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
