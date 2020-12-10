using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class TuristaListViewModel
    {
        public IEnumerable<Turista> Turista { get; set; }
        public PagingInfo Pagination { get; set; }
    }
}
