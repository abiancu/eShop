using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Extensions;
using SendGrid;

namespace AlejandroElectronics.Controllers
{


    public class LoginController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        private SignInManager<Models.ApplicationUser> _signInManager;  //inject sign in manager to able to read sing in info.
        private SendGridClient _sendGridClient;


        public LoginController(SignInManager<Models.ApplicationUser> signInManager, SendGrid.SendGridClient sendGridClient)
        {
            this._signInManager = signInManager;
            this._sendGridClient = sendGridClient;
            
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

        /// STEPS TO FORGOT PASSWORD
        /// 
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                string token = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
                token = System.Net.WebUtility.UrlEncode(token);
                //sending the password reset URL
                string currentUrl = Request.GetDisplayUrl(); // =>gets an URl for the user
                           
                Uri uri = new Uri(currentUrl); // => splits the URL Object into parts

                string resetUrl = uri.GetLeftPart(UriPartial.Authority); 
                resetUrl += "/login/resetpassword?id=" + token + "&email=" + email; //=> the resetUrl needs to go to the Login controller.

                SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                message.AddTo(email);
                message.Subject = "Password Reset"; // => this is the email Subject;
                message.SetFrom("alejandro.dev@alstore.com"); // => this is where it's comming from ; 
                message.AddContent("text/plain", resetUrl);
                message.AddContent("text/html", string.Format("<a href=\"{0}\">{0}</a>", resetUrl));
                await _sendGridClient.SendEmailAsync(message);

            }


            return RedirectToAction("Index", "Login");

        }

        public IActionResult ResetPassword()
        {
            return View();
        }


        // this will get call to reset the password///
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, string email, string password)
        {
            string originalToken = id;
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.UserManager.ResetPasswordAsync(user, originalToken, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login", new { resetSuccessful = true } );
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            return View();
        }

    }
}