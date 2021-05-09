using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidzWorld.Data;
using KidzWorld.Models;
using Microsoft.AspNetCore.Authorization;

namespace KidzWorld.Controllers
{
    [Authorize(Roles = "admin")]
    public class SellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sellers.ToListAsync());
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellr = await _context.Sellers
                .FirstOrDefaultAsync(m => m.SellerID == id);
            if (sellr == null)
            {
                return NotFound();
            }

            return View(sellr);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SellerID,SellerName,SellerAddress,SellerContact,ContactPerson")] Sellers sellr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellr);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellr = await _context.Sellers.FindAsync(id);
            if (sellr == null)
            {
                return NotFound();
            }
            return View(sellr);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SellerID,SellerName,SellerAddress,SellerContact,ContactPerson")] Sellers sellr)
        {
            if (id != sellr.SellerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellersExists(sellr.SellerID))
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
            return View(sellr);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellr = await _context.Sellers
                .FirstOrDefaultAsync(m => m.SellerID == id);
            if (sellr == null)
            {
                return NotFound();
            }

            return View(sellr);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellr = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(sellr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellersExists(int id)
        {
            return _context.Sellers.Any(e => e.SellerID == id);
        }
    }
}
