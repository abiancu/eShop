using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlejandroElectronics.Models;



namespace AlejandroElectronics.Controllers
{
    public class ShippingsController : Controller
    {
        private readonly AlejandroTestContext _context;
       
        private Braintree.BraintreeGateway _braintreeGateway; // => injecting braintree

        private SmartyStreets.USStreetApi.Client _usStreetClient; // => injecting SmartyStreets

        public ShippingsController(AlejandroTestContext context, Braintree.BraintreeGateway braintreeGateway, SmartyStreets.USStreetApi.Client usStreetClient)
        {
            _context = context;
            _braintreeGateway = braintreeGateway;
            _usStreetClient = usStreetClient;

        }
        
        
        /// <summary>
        /// this index method displays the cart information once its orders from the cart view.
        /// </summary>
        /// <returns>
        /// </returns>
       

        // GET: Shippings
        public async Task<IActionResult> Index()
        {
            
            ShippingsViewModel viewModel = new ShippingsViewModel();
            if (Request.Cookies.Keys.Contains("cartId") && Guid.TryParse(Request.Cookies["cartId"], out Guid cartId))
            {
                viewModel.Cart = await _context.Cart.Include(c => c.Product).Include(c => c.User).SingleAsync(x => x.CartId == cartId);
            }
            
            return View(viewModel);
        }


        /// <summary>
        /// ShippingViewModel displays cart information and payment infomration. 
        ///created the ShippingviewModel class 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ShippingsViewModel model) // this Model info needs to go to braintree.
        {
            Address address = new Address();
            if (Request.Cookies.Keys.Contains("cartId") && Guid.TryParse(Request.Cookies["cartId"], out Guid cartId))
            {
                model.Cart = await _context.Cart.Include(c => c.Product).Include(c => c.User).SingleAsync(x => x.CartId == cartId);
            }
            if (ModelState.IsValid)
            {
                Orders newOrder = new Orders();
                newOrder.User = model.Cart.User;
                newOrder.Product = model.Cart.Product;
                newOrder.LineItems.Add(new LineItem
                {
                    Product = model.Cart.Product,
                    Quantity = 1
                });
                newOrder.Shipping.Add(new Shipping
                {
                    Address = new Address
                    {
                        Street = "",
                        City = "",
                        State = "",
                        Zip = 0
                    }
                });
                if (ModelState.IsValid)
                {

                    // this is to interact with Braintree. Getting all the user card information and sending it to BrainTree.
                    Braintree.TransactionRequest saleRequest = new Braintree.TransactionRequest();
                    saleRequest.Amount = model.Cart.Product.Price.Value;
                    saleRequest.CreditCard = new Braintree.TransactionCreditCardRequest
                    {
                        CardholderName = model.CreditCartName,
                        CVV = model.CreditCardVerificationValue,
                        ExpirationMonth = model.ExpirationMonth,
                        ExpirationYear = model.ExpirationYear,
                        Number = model.CreditCardNumber
                        
                    };

                    // awaiting the result of card validation
                    var result = await _braintreeGateway.Transaction.SaleAsync(saleRequest);
                    if (result.IsSuccess())
                    {
                        _context.Orders.Add(newOrder); // => this adds the newly created order.
                        _context.Cart.Remove(model.Cart); // => once it's added, Remove() will clear out the cart.
                        Response.Cookies.Delete("cartId");// => Delete() will delete the cookie with the cart info.
                        //await _context.SaveChangesAsync(); => Question for joe: Why did I not have to use await_context.SaveChanges()?
                        return RedirectToAction("Index", "OrderComplete");
                       
                    }
                    foreach (var error in result.Errors.All())
                    {
                        ModelState.AddModelError(error.Code.ToString(), error.Message);
                    }
                }
                

                //return RedirectToAction("Index", "OrderComplete");
            }
            await _context.SaveChangesAsync();

            return View(model);
        }
    }
}
