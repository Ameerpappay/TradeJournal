using Application.Dtos.Holdings;
using Application.Dtos.Portfolio;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IHoldingsServices
    {
        Task<List<GetHoldingsDto>> GetHoldings(string userId);

        Task<GetHoldingsDto> GetHoldingByID(string HoldingId, string userId);


        Task<GetHoldingsDto> AddHoldings(AddHoldingsDto AddHoldingDto, string UserId);

        Task UpdateHoldings(string Id, UpdateHoldingsDto updateHoldingsDto, string userId);

        Task DeleteHoldingsById(string holdingId, string userId);
        //public Holdings GetExistingHolding(string code, int portfolioId);

    }
}
