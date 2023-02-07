using System;
using System.Collections.Generic;

#nullable disable

namespace DbTripalTest.LoanModels
{
    public partial class Pakiet
    {
        public int Id { get; set; }
        public int? NumerPakietu { get; set; }
        public int? X { get; set; }
        public int? Z { get; set; }
        public int? Y { get; set; }
        public int? IloscProduktow { get; set; }
        public int? Obrot { get; set; }
        public int? OrientacjaPobrania { get; set; }
        public int? WymiarX { get; set; }
        public int? WymiarY { get; set; }
        public int? Xoff { get; set; }
        public int? Yoff { get; set; }
        public DateTime? Data { get; set; }
        public int WarstwaId { get; set; }
 
        public  virtual Warstwa Warstwa { get; set; }



    }
}
