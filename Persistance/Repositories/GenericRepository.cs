
using Application.IRepositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TradeJournalDataContext _context;

        public GenericRepository(TradeJournalDataContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            var result = await _context.AddAsync(entity);

            return result.Entity;
        }

        public async Task Delete(string id, string createdById)
        {
            //var record = await _context.Set<T>().FindAsync(id);
            var record = await _context.Set<T>().FirstOrDefaultAsync(x => x.Identifier.ToString() == id && x.CreatedByUserId == createdById);

            if (record == null) throw new Exception("Not found");

            record.IsDeleted = true;
        }

        public virtual async Task<T> Get(string id, string createdById)
        {
            var record= await _context.Set<T>().FirstOrDefaultAsync(x => x.Identifier.ToString() == id && x.CreatedByUserId == createdById);
            return record;
        }

        public virtual async Task<IEnumerable<T>> Get(string createdById)
        {
            var result = await _context.Set<T>().Where(i => i.CreatedByUserId == createdById).ToListAsync();

            return result;
        }

        public async Task<T> Update(T entity)
        {
            var result = _context.Update(entity);

            return result.Entity;
        }
    }
}
