using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AlejandroElectronics.Controllers
{


    public class LoginController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        private SignInManager<Models.ApplicationUser> _signInManager;  //inject sign in manager to able to read sing in info.
        public LoginController(SignInManager<Models.ApplicationUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            if (ModelState.IsValid)
            {
                Models.ApplicationUser existingUser = _signInManager.UserManager.FindByNameAsync(username).Result;
                if (existingUser != null)
                {
                    //I found a user - try validating their password
                    if (_signInManager.UserManager.CheckPasswordAsync(existingUser, password).Result)
                    {
                        //I got the right password for the user - log them in!
                        _signInManager.SignInAsync(existingUser, false).Wait();
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("username", "Username or password is incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("username", "Username or password is incorrect");
                }

            }
            return View();
        }
    }
}