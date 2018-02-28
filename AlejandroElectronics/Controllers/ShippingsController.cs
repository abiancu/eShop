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

        public ShippingsController(AlejandroTestContext context)
        {
            _context = context;
        }

        // GET: Shippings
        public async Task<IActionResult> Index()
        {
            var alejandroTestContext = _context.Shipping.Include(s => s.Address).Include(s => s.Orders);
            return View(await alejandroTestContext.ToListAsync());
        }

        // GET: Shippings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping
                .Include(s => s.Address)
                .Include(s => s.Orders)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: Shippings/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id");
            ViewData["OrdersId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: Shippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrdersId,AddressId")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", shipping.AddressId);
            ViewData["OrdersId"] = new SelectList(_context.Orders, "Id", "Id", shipping.OrdersId);
            return View(shipping);
        }

        // GET: Shippings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping.SingleOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", shipping.AddressId);
            ViewData["OrdersId"] = new SelectList(_context.Orders, "Id", "Id", shipping.OrdersId);
            return View(shipping);
        }

        // POST: Shippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrdersId,AddressId")] Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(shipping.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", shipping.AddressId);
            ViewData["OrdersId"] = new SelectList(_context.Orders, "Id", "Id", shipping.OrdersId);
            return View(shipping);
        }

        // GET: Shippings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.Shipping
                .Include(s => s.Address)
                .Include(s => s.Orders)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: Shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipping = await _context.Shipping.SingleOrDefaultAsync(m => m.Id == id);
            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingExists(int id)
        {
            return _context.Shipping.Any(e => e.Id == id);
        }
    }
}
