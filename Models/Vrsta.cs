using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_01.Models
{
    public class Vrsta
    {
        public int Id { get; set; }

        public Auto Auto { get; set; }

        public Motori Motori { get; set; }

        public string Ime { get; set; }
        public string TipVozila  { get; set; }
    }
}
