using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "É necessário colocar uma data válida")]
        public DateTime DataReserva { get; set; }
        [Required(ErrorMessage = "É necessário indicar o número de pessoas")]
        public int NPessoas { get; set; }
    }
}
