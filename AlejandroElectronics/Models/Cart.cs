using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public string AspNetUserId { get; set; }
        public int ProductId { get; set; }

        public AspNetUsers AspNetUser { get; set; }
        public Products Product { get; set; }
    }
}
