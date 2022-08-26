using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext ctx,ILoggerFactory factory)
        {
            try
            {
                if(!ctx.ProductBrands.Any())
                {
                     var brandsData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");  

                     var brands= JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                     foreach(var item in brands)
                     {
                        ctx.ProductBrands.Add(item);
                     }
                     await ctx.SaveChangesAsync();
                }

                 if(!ctx.ProductTypes.Any())
                {
                     var brandsTypes=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");  

                     var Types= JsonSerializer.Deserialize<List<ProductType>>(brandsTypes);

                     foreach(var item in Types)
                     {
                        ctx.ProductTypes.Add(item);
                     }
                     await ctx.SaveChangesAsync();
                }

                 if(!ctx.Products.Any())
                {
                     var product=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");  

                     var Types= JsonSerializer.Deserialize<List<Product>>(product);

                     foreach(var item in Types)
                     {
                        ctx.Products.Add(item);
                     }
                     await ctx.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger= factory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
            }
            
        }
    }
}