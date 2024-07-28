using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class TradeJournalDataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public TradeJournalDataContext(DbContextOptions<TradeJournalDataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Holding> Holdings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Strategy>(options => options.HasIndex(m => new { m.Name, m.IsDeleted, m.CreatedByUserId }).IsUnique().HasFilter("\"IsDeleted\" = false"));
            modelBuilder.Entity<Portfolio>(options => options.HasIndex(m => new { m.Name, m.IsDeleted, m.CreatedByUserId }).IsUnique().HasFilter("\"IsDeleted\" = false"));

            // Get all DbSet properties in your DbContext
            var dbSetProperties = GetType().GetProperties()
                                            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            // Iterate over DbSet properties
            foreach (var dbSetProperty in dbSetProperties)
            {
                var entityType = dbSetProperty.PropertyType.GetGenericArguments().First();

                // Check if the entity inherits from BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entityType))
                {
                    // Get CreatedBy and UpdatedBy navigation properties
                    var identifierProperty = entityType.GetProperty("Identifier");

                    // Configure relationships if navigation properties exist
                    if (identifierProperty != null)
                    {
                        modelBuilder.Entity(entityType).HasIndex("Identifier").IsUnique();
                    }
                }
            }
        }
    }
}
