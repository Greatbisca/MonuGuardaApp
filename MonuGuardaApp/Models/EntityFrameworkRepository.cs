using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class EntityFrameworkRepository : MonuGuardaRepositorio
    {
        private MonuGuardaDbContext dbContext;

        public EntityFrameworkRepository(MonuGuardaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<VisitasGuiadas> VisitasGuiadas => dbContext.VisitasGuiadas;
    }
}
