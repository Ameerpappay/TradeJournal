﻿using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
     public class TradeRepository : GenericRepository<Trade>,ITradeRepository
     {
        private TradeJournalDataContext _dbContext;
        private DbSet<Trade> _dbSet;
        public TradeRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Trade>();
        }

        public async override Task<Trade> Get(int id)
        {
            var result = await _dbSet.Include(i=>i.Strategy).FirstOrDefaultAsync(x=>x.Id==id);

            return result;
        }

        public  override async Task<IEnumerable<Trade>> Get()
        {
            var result = await _dbSet.Include(i=>i.Strategy).ToListAsync();

            return result;

        }
    }
}
