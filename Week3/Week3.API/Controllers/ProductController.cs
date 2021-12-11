﻿using Microsoft.AspNetCore.Mvc;
using Week3.Model;
using Week3.Model.Product;
using Week3.Service.Product;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }


        [HttpPost("Insert")]
        public General<ProductViewModel> InsertProduct([FromBody] ProductViewModel newProduct)
        {
            return productService.InsertProduct(newProduct);
        }

        [HttpGet]
        public General<ProductViewModel> GetProducts()
        {
            return productService.GetProducts();
        }

        [HttpPut("{id}")]
        public General<ProductViewModel> UpdateProduct(int id, [FromBody] ProductViewModel product)
        {
            return productService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public General<ProductViewModel> DeleteProduct(int id)
        {
            return productService.DeleteProduct(id);
        }
    }
    
}
