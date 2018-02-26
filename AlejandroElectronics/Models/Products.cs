using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public int? Sku { get; set; }
        public DateTime? DateCreated { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
