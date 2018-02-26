using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }

        public ApplicationUser User { get; set; }
        public Products Product { get; set; }
    }
}
