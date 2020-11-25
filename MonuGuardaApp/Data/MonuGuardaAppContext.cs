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

        public DbSet<MonuGuardaApp.Models.Rotas> Rotas { get; set; }
    }
}
