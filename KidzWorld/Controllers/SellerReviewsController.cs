using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidzWorld.Data;
using KidzWorld.Models;

namespace KidzWorld.Controllers
{
    public class SellerReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellerReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SellerReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KdzSellerReview.Include(s => s.SellersReviews);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: SellerReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerReview = await _context.KdzSellerReview
                .Include(s => s.SellersReviews)
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (sellerReview == null)
            {
                return NotFound();
            }

            return View(sellerReview);
        }

        // POST: SellerReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerReview = await _context.KdzSellerReview.FindAsync(id);
            _context.KdzSellerReview.Remove(sellerReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerReviewExists(int id)
        {
            return _context.KdzSellerReview.Any(e => e.ReviewID == id);
        }
    }
}
