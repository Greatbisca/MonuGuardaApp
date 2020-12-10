using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class VisitasGuiadasListViewModel
    {
        public IEnumerable<VisitasGuiadas> VisitasGuiadas { get; set; }
        public PagingInfo Pagination { get; set; }
        

    }
}
