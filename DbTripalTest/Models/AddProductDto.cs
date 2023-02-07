using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbTripalTest.Models
{
    public class AddProductDto
    {

        [Required]
        public string NazwaProduktu { get; set; }

        [Required]
        public string WagaProduktu { get; set; }

        [Required]
        public string A { get; set; }

        [Required]
        public string B { get; set; }

        [Required]
        public string C { get; set; }

        public int? IloscWejsciowa { get; set; }
    }
}
