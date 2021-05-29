using System;
using System.Collections.Generic;

namespace eShop.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int AddressId { get; set; }
       
        public Address Address { get; set; }
        public Orders Orders { get; set; }
    }
}
