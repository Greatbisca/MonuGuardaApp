using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class Guia
    {
        public int GuiaId { get; set; }

        [Required(ErrorMessage = "É necessário colocar o nome")]
        [StringLength(20)]
        public string Nome { get; set; }

        public int Telemovel { get; set; }

        [Required(ErrorMessage = "É necessário colocar o email")]
        public string Email { get; set; }

        public byte[] Photo { get; set; }
    }
}
