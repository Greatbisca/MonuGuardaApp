using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class PontosdeInteresseListViewModel
    {
        public IEnumerable<PontosdeInteresse> PontosdeInteresse { get; set; }
        public PagingInfo Pagination { get; set; }
        public string SearchName { get; set; }
    }
}
