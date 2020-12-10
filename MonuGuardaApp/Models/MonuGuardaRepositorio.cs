﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class MonuGuardaRepositorio
    {
        public IEnumerable<VisitasGuiadas> VisitasGuiadas { get; }

        public IEnumerable<Turista> Turista { get; }
    }
}
