using Application.Dtos;
using Application.IRepositories;
using Application.IServices;
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
        public async Task<List<GetStrategyDto>> GetStrategies()
        {
            var result = await _unitOfWork.StrategyRepository.Get();

            var strategies  = result.Select(s=>new GetStrategyDto
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();

            return strategies;
        }
    }
}
