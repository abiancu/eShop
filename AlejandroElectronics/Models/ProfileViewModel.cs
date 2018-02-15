using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
 



namespace AlejandroElectronics.Models
{
    public class ProfileViewModel
    {
       
       public string name { get; set; }
       public string password { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name ="create an username")]
        public string username { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }


    }

  


}
