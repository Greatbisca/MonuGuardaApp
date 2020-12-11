using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class GuiaListViewModel
    {
        public IEnumerable<Guia> Guia{ get; set; }
        public PagingGuia Pagination { get; set; }

    }
}
