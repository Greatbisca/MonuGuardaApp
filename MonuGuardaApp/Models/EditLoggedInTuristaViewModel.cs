﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class EditLoggedInTuristaViewModel
    {
        [Required]
        [StringLength(128)]
        public string Nome { get; set; }
        public string Morada { get; set; }
        public int NIF { get; set; }
        public int Telemovel { get; set; }

        public string Email { get; set; }
    }
}   
