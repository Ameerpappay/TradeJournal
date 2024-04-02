﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Trade> Trades { get; set; } //noneed

        //listof holding
    }
}
