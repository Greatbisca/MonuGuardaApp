﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class MonuGuardaDbContext : DbContext
    {
        public MonuGuardaDbContext(DbContextOptions options) : base(options) { }
        public DbSet<VisitasGuiadas> VisitasGuiadas { get; set; }

        public DbSet<Turista> Turitas { get; set; }
    }
}
