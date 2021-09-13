using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntouchBilling.Entity;

namespace IntouchBilling.Data
{
    public class IntouchBillingContext : DbContext
    {
        public IntouchBillingContext (DbContextOptions<IntouchBillingContext> options)
            : base(options)
        {
        }

        public DbSet<IntouchBilling.Entity.Billing> Billing { get; set; }
    }
}
