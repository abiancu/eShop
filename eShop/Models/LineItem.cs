using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Products Product { get; set; }
        public Orders Order { get; set; }
    }
}
