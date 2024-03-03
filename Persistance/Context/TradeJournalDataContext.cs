using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
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
        DbSet<Trade> Trade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
