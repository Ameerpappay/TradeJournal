﻿using Application.Dtos;
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
    public class PortfolioService : IPortfolioServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PortfolioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetPortfolioDto> AddPortfolio(AddPortfolioDto portfolio)
        {
            var newPortfolio = new Portfolio()
            {
                Description = portfolio.Description,
                Name = portfolio.Name
            };

            var addedPortfolio = await _unitOfWork.PortfolioRepository.Add(newPortfolio);
            await _unitOfWork.SaveChangesAsync();
            return new GetPortfolioDto()
            {
                Description = addedPortfolio.Description,
                Name = addedPortfolio.Name,
                Id = addedPortfolio.Id
            };

        }

        public async Task DeletePortfolioById(int portfolioId)
        {
            await _unitOfWork.PortfolioRepository.Delete(portfolioId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetPortfolioDto>> GetPortfolio()
        {
            var result = await _unitOfWork.PortfolioRepository.Get();
            var portfolio = result.Select(s => new GetPortfolioDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return portfolio;
        }

        public async Task<GetPortfolioDto> GetPortfolioById(int portfolioId)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(portfolioId);
            var portfolio = new GetPortfolioDto();
            portfolio.Id = result.Id;
            portfolio.Name = result.Name;
            portfolio.Description = result.Description;
            return portfolio;
        }

        public async Task UpdatePortfolio(int Id, UpdatePortfolioDto updatePortfolioDto)
        {
            var result = await _unitOfWork.PortfolioRepository.Get(Id);
            result.Description = updatePortfolioDto.Description;
            result.Name = updatePortfolioDto.Name;

            await _unitOfWork.PortfolioRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}