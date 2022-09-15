using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Errors;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
       private readonly IGenericRepository<Product> _ProdRepo;
       private readonly IGenericRepository<ProductBrand> _ProductBrand;
       private readonly IGenericRepository<ProductType> _ProductType;

        public ProductsController(IGenericRepository<Product> ProdRepo
                                ,IGenericRepository<ProductBrand> prodBrand,
                                IGenericRepository<ProductType> prodType)
        {
            _ProdRepo=ProdRepo;
            _ProductBrand=prodBrand;
            _ProductType=prodType;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           // var spec=new ProductsWithTypesAndBrands();
            var prod=await _ProdRepo.ListAllAsync();
            return Ok(prod);
        }

         [HttpGet("{id}")]
         [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
           // var spec=new ProductsWithTypesAndBrands(id);
              return await _ProdRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductBrand.ListAllAsync());
        }

          [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProducttypes()
        {
            return Ok(await _ProductType.ListAllAsync());
        }
    }
}