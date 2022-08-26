using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _Repo;
        public ProductsController(IProductRepository Repo)
        {
            _Repo=Repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prod=await _Repo.GetProductsAsync();
            return Ok(prod);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          return await _Repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _Repo.GetProductBrandsAsync());
        }

          [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProducttypes()
        {
            return Ok(await _Repo.GetProductTypesAsync());
        }
    }
}