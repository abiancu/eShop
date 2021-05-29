using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Controllers
{

    public class OrderCompleteController : Controller
    {
        public OrderCompleteController(AlejandroTestContext context)
        {
            _context = context;
        }
        private AlejandroTestContext _context; 
       
       
        public async Task<IActionResult> Index(int id)
        {
            var order = await _context.Orders.Include(c => c.Product).Include(c => c.User).Include(c => c.Shipping).ThenInclude(c => c.Address).SingleAsync(x => x.Id == id);
            
            return View(order);


           
        }
    }
}