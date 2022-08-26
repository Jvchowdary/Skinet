using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
     {
       // public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public string PictureUrl { get; set; }
        public int productTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public ProductType ProductType { get; set; } //related Entities
        public ProductBrand ProductBrand { get; set; }


        
    }
}