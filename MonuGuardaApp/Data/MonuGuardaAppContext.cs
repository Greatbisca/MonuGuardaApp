﻿using System;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //modelBuilder.Entity<ReservaVisita>()
           //     .HasKey(bc => new {bc.VisitasGuiadasId });

           // modelBuilder.Entity<ReservaVisita>()
           //     .HasOne(bc => bc.VisitasGuiadas)
           //     .WithMany(c => c.ReservasVisita)
           //     .HasForeignKey(bc => bc.VisitasGuiadasId)
           //     .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<MonuGuardaApp.Models.Guia> Guia { get; set; }

        public DbSet<MonuGuardaApp.Models.PontosdeInteresse> PontosdeInteresse { get; set; }

        public DbSet<MonuGuardaApp.Models.PontosVisita> PontosVisita { get; set; }

        public DbSet<MonuGuardaApp.Models.ReservaVisita> ReservaVisita { get; set; }

        public DbSet<MonuGuardaApp.Models.Turista> Turista { get; set; }

        public DbSet<MonuGuardaApp.Models.VisitasGuiadas> VisitasGuiadas { get; set; }

        public DbSet<MonuGuardaApp.Models.Freguesia> Freguesia { get; set; }

        public DbSet<MonuGuardaApp.Models.Concelho> Concelho { get; set; }
    }
}
