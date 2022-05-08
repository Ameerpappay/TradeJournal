using Application.Common.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext :DbContext,IApplicationDbContext
    {

        #region private Properties
        private DateTime _currentDateTime { get; set; }
        #endregion
        #region constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
:base(options)
        {
            this._currentDateTime = DateTime.Now;
        }
        #endregion
        public DbSet<Trade> Trades { get; set; }

        public Task<int> SaveChangesAsync()
        {
           foreach(var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = 1;
                        entry.Entity.CreatedDate = _currentDateTime;
                        entry.Entity.ModifiedBy = 1;
                        entry.Entity.ModifiedDate = _currentDateTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = 1;
                        entry.Entity.ModifiedDate = _currentDateTime;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IApplicationDbContext).Assembly);
        }
    }
}
