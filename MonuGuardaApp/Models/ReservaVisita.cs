using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class ReservaVisita
    {
        public int ReservaVisitaId { get; set; }
        public int TuristaId { get; set; }
        public Turista Turista { get; set; }
        public int VisitasGuiadasId { get; set; }
        public VisitasGuiadas VisitasGuiadas { get; set; }
        public DateTime DataReserva { get; set; }
        public int NPessoas { get; set; }
    }
}
