using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using iceOne_Cloud.Models;

namespace iceOne_Cloud.Data
{
    public class iceOne_CloudContext : DbContext
    {
        public iceOne_CloudContext()
        {
        }

        public iceOne_CloudContext (DbContextOptions<iceOne_CloudContext> options)
            : base(options)
        {
        }

        public DbSet<iceOne_Cloud.Models.bnbDB> bnbDB { get; set; } = default!;
    }
}
