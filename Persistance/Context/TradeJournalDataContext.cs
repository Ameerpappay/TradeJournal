using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class TradeJournalDataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public TradeJournalDataContext(DbContextOptions<TradeJournalDataContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Strategy> Strategies { get; set; }
        DbSet<Portfolio> Portfolio { get; set; }      
        public DbSet<Trade> Trade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Strategy>(options => options.HasKey(m => m.Name));

            // Get all DbSet properties in your DbContext
            var dbSetProperties = GetType().GetProperties()
                                            .Where(p => p.PropertyType.IsGenericType
                                                    && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            // Iterate over DbSet properties
            foreach (var dbSetProperty in dbSetProperties)
            {
                var entityType = dbSetProperty.PropertyType.GetGenericArguments().First();

                // Check if the entity inherits from BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entityType))
                {
                    // Get CreatedBy and UpdatedBy navigation properties
                    var createdByProperty = entityType.GetProperty("CreatedBy");
                    var updatedByProperty = entityType.GetProperty("UpdatedBy");

                    // Configure relationships if navigation properties exist
                    if (createdByProperty != null && updatedByProperty != null)
                    {
                        modelBuilder.Entity(entityType)
                            .HasOne(createdByProperty.PropertyType, "CreatedBy")
                            .WithMany()
                            .HasForeignKey("CreatedByUserId")
                            .OnDelete(DeleteBehavior.Restrict);

                        modelBuilder.Entity(entityType)
                            .HasOne(updatedByProperty.PropertyType, "UpdatedBy")
                            .WithMany()
                            .HasForeignKey("UpdatedByUserId")
                            .OnDelete(DeleteBehavior.Restrict);

                        // Set foreign key property names to match navigation property names
                        modelBuilder.Entity(entityType)
                            .HasIndex("CreatedByUserId");

                        modelBuilder.Entity(entityType)
                            .HasIndex("UpdatedByUserId");
                    }
                }
            }
        }
    }
}
