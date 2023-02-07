using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbTripalTest.LoanModels;
using DbTripalTest.Models;

namespace DbTripalTest.Mapping
{
    public class ProductMapingProfilecs : Profile
    {
        public ProductMapingProfilecs()
        {
            CreateMap<AddProductDto, Produkt>();
        }
    }
}
