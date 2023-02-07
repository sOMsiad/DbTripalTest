using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbTripalTest.LoanModels;
using DbTripalTest.Models;

namespace DbTripalTest.Service
{
    public interface IProductService
    {
        int Add(AddProductDto productDto);
        Produkt Update(AddProductDto productDto, int id);
        List<Produkt> GetAll();
    }

    public class ProductService : IProductService
    {
        private readonly TripalDbContext _dbContext;
        private readonly IMapper _iMapper;

        public ProductService(TripalDbContext dbContext,IMapper iMapper)
        {
            _dbContext = dbContext;
            _iMapper = iMapper;
        }
        public int Add(AddProductDto productDto)
        {
            var product = _iMapper.Map<Produkt>(productDto);
            _dbContext.Produkty.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }
        public  Produkt Update(AddProductDto productDto, int id)
        {
            
            var product = _dbContext.Produkty
                .FirstOrDefault(p => p.Id == id);
            product.NazwaProduktu = productDto.NazwaProduktu;
            product.A = productDto.A;
            product.B = productDto.B;
            product.C = productDto.C;
            product.IloscWejsciowa = productDto.IloscWejsciowa;
       //     _dbContext.Produkty.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public List<Produkt> GetAll()
        {
            var Produkty = _dbContext.Produkty;
            return Produkty.ToList();
        }

   
    }
}
