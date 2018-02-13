using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlejandroElectronics.Controllers
{
    public class ProductsController : Controller
    {
    

        public IActionResult Index(int Sku)
        {
            Models.ProductsViewModel model = new Models.ProductsViewModel();
            if(Sku==300)
            {
                          
                model.Name = "Mac Air";
                model.Price = 299.99m;
                model.Sku = 300;
                model.Description = "Pretty cool laptop";
                model.ImageUrl = "/images/computer1.jpg";
            } 
            else if (Sku==400)
            {
                model.Name = "Surface";
                model.Price = 399.99m;
                model.Sku = 400;
                model.Description = "Pretty cool laptop";

            }
            else if (Sku == 500)
            {
                model.Name = "Toshiba";
                model.Price = 899.99m;
                model.Sku = 500;
                model.Description = "It's Ok!";
                model.ImageUrl = "/images/toshiba.jpg";
            }
            
           
            return View(model);

        }
    }
}