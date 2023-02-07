using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace DbTripalTest.LoanModels
{
    public class Warstwa
    {
        public int  Id { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public DateTime DataOstatniejAktualizacji { get; set; }
        public int ProduktId { get; set; }
        public Produkt Produkt{ get; set; }
        public List<Pakiet> Pakiety { get; set; }
        public List<Poziomy> Poziomy { get; set; }

    }
}
