using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eShop.Models;

namespace eShop.Controllers
{
    public class CartController : Controller
    {
        private eShopTestContext _context; // changed from"private readonly eShop..., to: "private eShopTestContext"
       

        public CartController(eShopTestContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
          
            Cart cart = new Cart();
            if(Request.Cookies.Keys.Contains("cartId") && Guid.TryParse(Request.Cookies["cartId"], out  Guid cartId))
            {
                cart = await _context.Cart.Include(c => c.Product).Include(c => c.User).SingleAsync(x => x.CartId == cartId);
            }
            
            //return View(await alejandroTestContext.ToListAsync());
            return View(cart);
        }
        
    }
}
