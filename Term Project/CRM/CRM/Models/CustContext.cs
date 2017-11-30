using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class CustContext : DbContext
    {
        public CustContext(DbContextOptions<CustContext> options)
                : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
