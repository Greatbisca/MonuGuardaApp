using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class ReservaVisitasListViewModel
    {
        public IEnumerable<ReservaVisita> ReservaVisitas { get; set; }
        public Turista Turista { get; set; }
        public PagingInfo Pagination { get; set; }
        public DateTime? SearchDataInicio { get; set; }
        public DateTime? SearchDataFim { get; set; }
    }
}
