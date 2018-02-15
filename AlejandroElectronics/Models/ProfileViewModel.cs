using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
 



namespace AlejandroElectronics.Models
{
    public class ProfileViewModel
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string password { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string username { get; set; }


        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "You need to enter an address")]
        public string address { get; set; }



        public string address2 { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string city { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        public string states { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int zip { get; set; }


    }

  


}
