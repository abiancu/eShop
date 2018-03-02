using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int AddressId { get; set; }
        //public string UserId { get; set; } // copied this line from Cart to check if shippings runs. 
        //public ApplicationUser User { get; set; }// copied this line from Cart to check if shippings runs. 
        public Address Address { get; set; }
        public Orders Orders { get; set; }
    }
}
