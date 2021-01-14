using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class PontosdeInteresse
    {
        public int PontosdeInteresseId { get; set; }

        [Required(ErrorMessage = "É necessário colocar nome")]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar freguesia")]
        [StringLength(20)]
        public string Freguesia { get; set; }

        [Required(ErrorMessage = "É necessário colocar concelho")]
        [StringLength(20)]
        public string Concelho { get; set; }

        [Required(ErrorMessage = "É necessário colocar morada")]
        [StringLength(100)]
        public string Morada { get; set; }

        [Required(ErrorMessage = "É necessário colocar coordenadas")]
        [StringLength(100)]
        public string Coordenadas { get; set; }
    }
}
