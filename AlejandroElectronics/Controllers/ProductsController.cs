using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlejandroElectronics.Models;
using Microsoft.Extensions.Options;

namespace AlejandroElectronics.Controllers
{
    public class ProductsController : Controller
    {
        private AlejandroTestContext _context;

        public ProductsController(AlejandroTestContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? Sku)
        {
            if (!Sku.HasValue)
            {
                return View(_context.Products);
            }
            else
            {
                return View(_context.Products.Where(x => x.Id == Sku.Value));
            }
           

        }

        [HttpPost]
        public IActionResult Index(int? Sku, bool extra)
        {
            string productsName = Sku.HasValue ? Sku.Value.ToString() : "product name";
           // Request.Cookies.TryGetValue("Sku", out productsName);
            ViewData["productName"] = productsName;

            return RedirectToAction("Index", "Cart");
        }


       


    }
}