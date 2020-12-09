using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDB_MIA.Models;

namespace WebDB_MIA.Data
{
    public class WebDB_MIAContext : DbContext
    {
        public WebDB_MIAContext (DbContextOptions<WebDB_MIAContext> options)
            : base(options)
        {
        }

        public DbSet<WebDB_MIA.Models.Casualtie> Casualtie { get; set; }

        public DbSet<WebDB_MIA.Models.Criminal> Criminal { get; set; }

        public DbSet<WebDB_MIA.Models.Position> Position { get; set; }

        public DbSet<WebDB_MIA.Models.Rank> Rank { get; set; }

        public DbSet<WebDB_MIA.Models.Staff> Staff { get; set; }

        public DbSet<WebDB_MIA.Models.TypeCrime> TypeCrime { get; set; }
    }
}
