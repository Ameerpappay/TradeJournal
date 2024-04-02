using Application.Dtos.Holdings;
using Application.Dtos.Portfolio;
using Application.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HoldingsService : IHoldingsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public HoldingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetHoldingsDto> AddHoldings(AddHoldingsDto AddHoldingDto, string UserId)
        {
            var newHoldings = new Holdings()
            {
                Code = AddHoldingDto.Code,
                BuyPrice = AddHoldingDto.BuyPrice,
                TrailingStoploss = AddHoldingDto.TrailingStoploss,
                Quantity = AddHoldingDto.Quantity,
                PortfolioId = AddHoldingDto.PortfolioId,
            };

            var addedHoldings = await _unitOfWork.HoldingsRepository.Add(newHoldings);

            await _unitOfWork.SaveChangesAsync();
            return new GetHoldingsDto()
            {
                Code = addedHoldings.Code,
                Quantity = addedHoldings.Quantity,
                BuyPrice = addedHoldings.BuyPrice,
                TrailingStoploss = addedHoldings.TrailingStoploss,
                PortfolioId = addedHoldings.PortfolioId,
            };
        }

        public async Task DeleteHoldingsById(string holdingId, string userId)
        {
            await _unitOfWork.HoldingsRepository.Delete(holdingId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetHoldingsDto> GetHoldingByID(string HoldingId, string userId)
        {
            var result = await _unitOfWork.HoldingsRepository.Get(HoldingId, userId);
            var holding = new GetHoldingsDto();
            holding.Id = result.Id;
            holding.Code = result.Code;
            holding.Quantity = result.Quantity;
            holding.TrailingStoploss= result.TrailingStoploss;
            holding.BuyPrice= result.BuyPrice;
            holding.PortfolioId = result.PortfolioId;
            return holding;
        }

        public async Task<List<GetHoldingsDto>> GetHoldings(string userId)
        {
            var result = await _unitOfWork.HoldingsRepository.Get(userId);
            var holding = result.Select(s => new GetHoldingsDto
            {
                Id = s.Id,
                Code = s.Code,
                BuyPrice= s.BuyPrice,
                Quantity= s.Quantity,
                PortfolioId= s.PortfolioId,
                TrailingStoploss= s.TrailingStoploss,

            }).ToList();

            return holding;
        }

        public async Task UpdateHoldings(string Id, UpdateHoldingsDto updateHoldingsDto, string userId)
        {
            var result = await _unitOfWork.HoldingsRepository.Get(Id, userId);
            result.Code = updateHoldingsDto.Code;
            result.BuyPrice = updateHoldingsDto.BuyPrice;
            result.Quantity = updateHoldingsDto.Quantity;
            result.PortfolioId= updateHoldingsDto.PortfolioId;           

            await _unitOfWork.HoldingsRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
