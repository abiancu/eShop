using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlejandroElectronics.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public string ImageUrl { get; set; }
        public int? Sku { get; set; }
        public DateTime? DateCreated { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
