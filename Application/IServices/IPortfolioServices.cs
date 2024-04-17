﻿using Application.Dtos.Strategy;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Portfolio;

namespace Application.IServices
{
    public interface IPortfolioServices
    {
        Task<List<GetPortfolioDto>> GetPortfolio(string userId);

        Task<GetPortfolioDto> AddPortfolio(AddPortfolioDto portfolio,string UserId);

        Task<GetPortfolioDto> GetPortfolioById(string portfolioId, string userId);

        Task<int> GetPortfolioId(string portfolioId, string userId);

        Task UpdatePortfolio(string Id, UpdatePortfolioDto updatePortfolioDto, string userId);

        Task DeletePortfolioById(string portfolioId, string userId);
    }
}
