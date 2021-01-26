using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class FreguesiaListViewModel
    {
        public IEnumerable<Freguesia> Freguesias { get; set; }
        public PagingInfo Pagination { get; set; }
        public string SearchName { get; set; }
    }
}
