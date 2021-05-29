using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShop.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }

        public ApplicationUser User { get; set; }

        [DataType(DataType.Currency)]
        public Products Product { get; set; }
        
        
    }
}
