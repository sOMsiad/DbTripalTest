using System;
using System.Collections.Generic;

#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class Uklad
    {
        public int Id { get; set; }
        public string NazwaUkladu { get; set; }
        public int IloscWarstw { get; set; }
        public DateTime Data { get; set; }
        public int ProduktId { get; set; }
        public int PaletaId { get; set; }
        public virtual Paleta Paleta { get; set; }
        public virtual List<Poziomy> UkladWarstw { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}
