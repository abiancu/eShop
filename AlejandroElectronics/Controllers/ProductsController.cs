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
            model.Products = new Models.Product[]
            {
                new Models.Product
                {
                    Name = "Mac Air",
                    Price = 299.99m,
                    Sku = 300,
                        Description = "Pretty cool laptop",
                        ImageUrl = "/images/computer1.jpg"
                },
                new Models.Product
                {
                     Name = "Surface",
                    Price = 399.99m,
                    Sku = 400,Description = "Pretty cool laptop",
                    ImageUrl = "/images/surface.jpg"

                },
                new Models.Product{

                    Name = "Toshiba",
                    Price = 899.99m,
                    Sku = 500,
                    Description = "It's Ok!",
                    ImageUrl = "/images/toshiba.jpg"
                }
            };
            if (Sku > 0)
            {
                model.Products = model.Products.Where(x => x.Sku == Sku).ToArray();
            }


            return View(model);

        }

        [HttpGet]
        public IActionResult Index()
        {
            string productsName = "your alpaca";
            Request.Cookies.TryGetValue("productID", out productsName);
            ViewData["alpacaName"] = productsName;

            return View();
        }


       


    }
}