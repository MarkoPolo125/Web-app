using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_01.Models;

namespace Projekt_01.Data
{
    public class TablicaContext : DbContext
    {
        public TablicaContext (DbContextOptions<TablicaContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt_01.Models.Auto> Auto { get; set; }

        public DbSet<Projekt_01.Models.Motori> Motori { get; set; }

        public DbSet<Projekt_01.Models.Vrsta> Vrsta { get; set; }
    }
}
