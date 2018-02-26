using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Payments = new HashSet<Payments>();
            Shipping = new HashSet<Shipping>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }

        public Products Product { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<Shipping> Shipping { get; set; }
    }
}
