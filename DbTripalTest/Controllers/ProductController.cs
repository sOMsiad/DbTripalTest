using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbTripalTest.Models;
using DbTripalTest.Service;
using Microsoft.AspNetCore.Mvc;

namespace DbTripalTest.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPut("{id}")]
        public ActionResult EditProduct([FromBody] AddProductDto dto, [FromRoute] int id )
        {
            var UpdatedProduct = _productService.Update(dto, id);
            return Ok(UpdatedProduct);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] AddProductDto dto)
        {
            var id = _productService.Add(dto);
            return Created($"api/product/{id}", null);
        }
        [HttpGet]

        public ActionResult GetAll()
        {
            var Produkty = _productService.GetAll();
            return Ok(Produkty);
        }

    }
}
