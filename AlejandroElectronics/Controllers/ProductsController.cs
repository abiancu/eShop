using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlejandroElectronics.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            Models.ProductsViewModel model = new Models.ProductsViewModel();
            model.Name = "Albert";
            model.Price = 299.99m;
            model.DietaryRequirements = "Grass, Hay, Carrots, Cap'n Crunch";
            model.Description = "Albert is an absolutely perfect Alpaca";
            model.Age = 4;
            model.Temperment = "Pleasant";
            model.ImageUrl = "/images/computer1.jpg";
           


            return View(model);
        }
    }
}