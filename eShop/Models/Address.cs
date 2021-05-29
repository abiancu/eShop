using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Address
    {
        public Address()
        {
            Shipping = new HashSet<Shipping>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }

        public ICollection<Shipping> Shipping { get; set; }
    }
}
