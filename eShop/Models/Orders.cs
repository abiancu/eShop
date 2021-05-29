using System;
using System.Collections.Generic;

namespace eShop.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Payments = new HashSet<Payments>();
            Shipping = new HashSet<Shipping>();
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }

        public Products Product { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<Shipping> Shipping { get; set; }

        public ApplicationUser User { get; set; } // orders belong to users
        public ICollection<LineItem> LineItems { get; set; }
    }
}
