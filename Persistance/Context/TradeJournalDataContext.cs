using Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class TradeJournalDataContext :DbContext
    {
        public TradeJournalDataContext(DbContextOptions<TradeJournalDataContext> options) : base(options) 
        { 
        }

        DbSet<Strategy> Strategies { get; set; }

        DbSet<Trade> Trade { get; set; }
    }
}
