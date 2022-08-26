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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
             return await _Ctx.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _Ctx.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .FirstOrDefaultAsync(p=>p.id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _Ctx.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return await _Ctx.ProductTypes.ToListAsync();
        }
    }
}