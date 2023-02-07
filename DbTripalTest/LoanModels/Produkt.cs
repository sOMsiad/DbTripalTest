using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class Produkt
    {
        public int Id { get; set; }
        public string NazwaProduktu { get; set; }
        public string WagaProduktu { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public int? IloscWejsciowa { get; set; }
        public DateTime DataUtworzenia { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DataOstatniejAktualizacji { get; set; }
        public virtual List<Warstwa> Warstwy { get; set; }
        public virtual  List<Uklad> Uklady { get; set; }
      
    }
}
