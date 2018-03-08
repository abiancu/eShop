using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroElectronics.Models
{
    public class ShippingsViewModel
    {
        public Cart Cart { get; set; }
        public Address address { get; set; }

        [CreditCard]
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CreditCartName { get; set; }
        [Required]
        public string CreditCardVerificationValue { get; set; }
        [Required]
        public string ExpirationMonth { get; set; }
        [Required]
        public string ExpirationYear { get; set; }
    }
}
