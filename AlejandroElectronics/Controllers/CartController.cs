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
    public class CartController : Controller
    {
        private readonly AlejandroTestContext _context;
        private string cartId;
        private Guid cartGuid;

        public CartController(AlejandroTestContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var alejandroTestContext = _context.Cart.Include(c => c.Product).Include(c => c.User);
            //return View(await alejandroTestContext.ToListAsync());
            return View(await alejandroTestContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(int? id)
        {
            //CODE TO CREATE THE COOKIE
            

           


            //CODE TO READ THE COOKIE
           
            return RedirectToAction("Index", "Shipping");


        }


        // GET: Cart/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Product)
                .Include(c => c.User)
                .Include(c => c.Product.Price)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Shipping");
        }


        // POST: Cart/Create



        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CartId,UserId,ProductId")] Cart cart)
        //{
        //    if (id != cart.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cart);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CartExists(cart.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ImageUrl", cart.ProductId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", cart.UserId);
        //    return View(cart);
        //}

        //// GET: Cart/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart
        //        .Include(c => c.Product)
        //        .Include(c => c.User)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cart);
        //}

        //// POST: Cart/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var cart = await _context.Cart.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Cart.Remove(cart);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CartExists(int id)
        //{
        //    return _context.Cart.Any(e => e.Id == id);
        //}
    }
}
