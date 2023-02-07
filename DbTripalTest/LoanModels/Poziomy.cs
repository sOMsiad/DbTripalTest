using System;
using System.Collections.Generic;

#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class Poziomy
    {
        public int Id { get; set; }
        public int NumerPoziomu { get; set; }
      
        public bool Przekladka { get; set; }
        public int WysokoscWarstwy { get; set; }
        public bool PaletaJakoPrzekladka { get; set; }
        public DateTime Data { get; set; }
        public int WarstwaId { get; set; }
        public int UkladId { get; set; }

        public virtual Uklad Uklad { get; set; }
        public virtual Warstwa Warstwa { get; set; }
        
    }
}
