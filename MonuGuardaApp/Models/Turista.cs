﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class Turista
    {
        public int TuristaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Morada { get; set; }
        public int NIF { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Telemovel { get; set; }
        public ICollection<ReservaVisita> ReservaVisitas { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
