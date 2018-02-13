using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroElectronics.Models
{
    
    public class ProductsViewModel
    {
        
        public string Name { get; set; }
        public int Sku { get; set; }
        public string Description { get; set; }        
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
