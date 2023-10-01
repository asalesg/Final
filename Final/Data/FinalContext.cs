using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final.Model;

namespace Final.Data
{
    public class FinalContext : DbContext
    {
        public FinalContext (DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public DbSet<Final.Model.InterpolFbi> InterpolFbi { get; set; } = default!;
    }
}
