using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonuGuardaApp.Models;

namespace MonuGuardaApp.Data
{
    public class MonuGuardaAppContext : DbContext
    {
        public MonuGuardaAppContext (DbContextOptions<MonuGuardaAppContext> options)
            : base(options)
        {
        }

        public DbSet<MonuGuardaApp.Models.Guia> Guia { get; set; }

        public DbSet<MonuGuardaApp.Models.PontosdeInteresse> PontosdeInteresse { get; set; }

        public DbSet<MonuGuardaApp.Models.PontosVisita> PontosVisita { get; set; }

        public DbSet<MonuGuardaApp.Models.ReservaVisita> ReservaVisita { get; set; }

        public DbSet<MonuGuardaApp.Models.Turista> Turista { get; set; }

        public DbSet<MonuGuardaApp.Models.VisitasGuiadas> VisitasGuiadas { get; set; }
    }
}
