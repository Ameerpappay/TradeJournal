﻿using Application.Dtos.Holdings;
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
        private readonly IPortfolioServices _portfolioServices;
        public HoldingsService(IUnitOfWork unitOfWork , IPortfolioServices portfolioServices)
        {
            _unitOfWork = unitOfWork;
            _portfolioServices = portfolioServices;
        }

        public async Task<GetHoldingsDto> AddHoldings(AddHoldingsDto AddHoldingDto, string UserId)
        {
            Holdings availTrade = await _unitOfWork.HoldingsRepository.GetExistingHolding(AddHoldingDto.Code,AddHoldingDto.PortfolioId);

            if (availTrade == null )
            {
                var newHoldings = new Holdings()
                {
                    Code = AddHoldingDto.Code,
                    BuyPrice = AddHoldingDto.BuyPrice,
                    TrailingStoploss = AddHoldingDto.TrailingStoploss,
                    Quantity = AddHoldingDto.Quantity,
                    PortfolioId = AddHoldingDto.PortfolioId,
                    CreatedByUserId = UserId,

                };

                var addedHoldings = await _unitOfWork.HoldingsRepository.Add(newHoldings);
                await _unitOfWork.SaveChangesAsync();
                return new GetHoldingsDto()
                {
                    Id = addedHoldings.Id,
                    Code = addedHoldings.Code,
                    Quantity = addedHoldings.Quantity,
                    BuyPrice = addedHoldings.BuyPrice,
                    TrailingStoploss = addedHoldings.TrailingStoploss,
                    PortfolioId = addedHoldings.PortfolioId,

                };
            }
            else
            {
                var updateHoldings = new Holdings()
                {
                    BuyPrice = AddHoldingDto.BuyPrice,
                    TrailingStoploss = AddHoldingDto.TrailingStoploss,
                    Quantity = AddHoldingDto.Quantity,
                    PortfolioId = AddHoldingDto.PortfolioId,
                    CreatedByUserId = UserId,

                };
                var addedHoldings = await _unitOfWork.HoldingsRepository.Update(updateHoldings);

                await _unitOfWork.SaveChangesAsync();

                return new GetHoldingsDto()
                {
                    Id = addedHoldings.Id,
                    Code = addedHoldings.Code,
                    Quantity = addedHoldings.Quantity,
                    BuyPrice = addedHoldings.BuyPrice,
                    TrailingStoploss = addedHoldings.TrailingStoploss,
                    PortfolioId = addedHoldings.PortfolioId,
                };
            }                 
        }

        public async Task DeleteHoldingsById(string holdingId, string userId)
        {
            await _unitOfWork.HoldingsRepository.Delete(holdingId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

      

        public Holdings GetExistingHolding(string code, int portfolioId)
        {
            throw new NotImplementedException();
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
