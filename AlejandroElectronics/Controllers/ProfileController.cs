using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlejandroElectronics.Models
{
    public class ProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProfileViewModel model)
        {

            if (ModelState.IsValid)
            {
                ViewData["Title"] = "Welcome";
                return this.RedirectToAction("Welcome", "Home");
            }
            else
            {
                return View(model);
            }
            

           
        }

        


    }
}