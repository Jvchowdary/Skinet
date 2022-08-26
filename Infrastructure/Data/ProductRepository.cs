using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _Ctx;
        public ProductRepository(StoreContext Ctx)
        {
            this._Ctx=Ctx;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _Ctx.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _Ctx.Products.ToListAsync();
        }
    }
}