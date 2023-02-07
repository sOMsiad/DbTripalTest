using System;
using System.Collections.Generic;

#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class Paleta
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Dlugosc { get; set; }
        public int Szerokosc { get; set; }
        public int Wysokosc { get; set; }
        public string Opis { get; set; }
        public DateTime? Data { get; set; }
        public virtual List<Uklad> Uklady { get; set; }
    }
}
