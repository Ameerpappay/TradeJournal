using Application.IRepositories;
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
    public class ImageRepository : GenericRepository<TradeImage>, IImageRepository
    {
        private TradeJournalDataContext _dbContext;
        private DbSet<TradeImage> _dbSet;
        public ImageRepository(TradeJournalDataContext _context)  :base(_context)
        {
            this._dbContext = _context;
            _dbSet = _dbContext.Set<TradeImage>();
        }
    }
}
