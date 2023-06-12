using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class TradeJournalDataContext : DbContext
    {
        public TradeJournalDataContext(DbContextOptions<TradeJournalDataContext> options) : base(options) { }

        DbSet<Strategy> Strategies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Strategy>().HasData(new Strategy { Id = 1, Name = "Seed Data 1" ,Description="None"});
        }
    }
}
