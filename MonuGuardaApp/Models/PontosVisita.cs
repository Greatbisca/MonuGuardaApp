using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class PontosVisita
    {
        public int PontosVisitaId { get; set; }
        public int PontosdeInteresseId { get; set; }
        public PontosdeInteresse PontosdeInteresse { get; set; }
        public int VisitasGuiadasId { get; set; }
        public VisitasGuiadas VisitasGuiadas { get; set; }
        [Required(ErrorMessage = "É necessário colocar a ordem")]
        public int Ordem { get; set; }

    }
}
