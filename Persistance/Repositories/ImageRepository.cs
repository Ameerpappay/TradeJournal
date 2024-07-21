using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class ImageRepository : GenericRepository<TradeImage>, IImageRepository
    {
        private TradeJournalDataContext _dbContext;
        private DbSet<TradeImage> _dbSet;
        public ImageRepository(TradeJournalDataContext _context) : base(_context)
        {
            this._dbContext = _context;
            _dbSet = _dbContext.Set<TradeImage>();
        }
    }
}
