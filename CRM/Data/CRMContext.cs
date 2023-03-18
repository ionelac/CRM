using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM.Models;

namespace CRM.Data
{
    public class CRMContext : DbContext
    {
        public CRMContext (DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public DbSet<CRM.Models.Pipeline> Pipeline { get; set; } = default!;

        public DbSet<CRM.Models.Contact> Contact { get; set; }

        public DbSet<CRM.Models.Salesperson>? Salesperson { get; set; }
    }
}
