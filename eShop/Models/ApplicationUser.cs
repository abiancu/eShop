using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        //Extending IdentityFramework -- THis allows ASP.net tables to include additional info from the user's profile.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColor { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ApplicationUser()
        {
            Reviews = new HashSet<Review>();
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
    
}
