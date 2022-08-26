using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _ctx;
        public ProductsController(StoreContext ctx)
        {
            this._ctx=ctx;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prod=await _ctx.Products.ToListAsync();
            return Ok(prod);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          return await _ctx.Products.FindAsync(id);
        }
    }
}