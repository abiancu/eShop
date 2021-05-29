using System;
using System.Collections.Generic;

namespace AlejandroElectronics.Models
{
    public partial class Payments
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }

        public Orders Orders { get; set; }
    }
}
