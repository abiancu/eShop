using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;


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

        private SignInManager<ApplicationUser> _signInManager;
        private SendGridClient _sendGridClient;

        public ProfileController(SignInManager<ApplicationUser> signInManager, SendGrid.SendGridClient sendGridClient)
        {
            this._signInManager = signInManager;
            this._sendGridClient = sendGridClient;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password, string email)  // add Task<IActionResult> and add mark code await where there is .Result and .wait();
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser(username);
                newUser.Email = email;
                var userResult = _signInManager.UserManager.CreateAsync(newUser).Result;
                if (userResult.Succeeded)
                {
                    var passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, password).Result;
                    if (passwordResult.Succeeded)
                    {
                        //TODO: Send a user a message thanking them for creating an account; 

                        SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                        message.AddTo(email);
                        message.Subject = "Welcome to CompiFuture Electronics";
                        message.SetFrom("AlejandroElectronics@compifuture.com");
                        message.AddContent("text/plain", "Thank you for registering  " + username + " on CompiFuture!");
                        _sendGridClient.SendEmailAsync(message);

                        _signInManager.SignInAsync(newUser, false).Wait(); // changed the register method to: RegisterAsync
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        _signInManager.UserManager.DeleteAsync(newUser).Wait();
                    }
                }
                else
                {
                    foreach (var error in userResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        
    }
}