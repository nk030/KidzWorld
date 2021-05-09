using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KidzWorld.Models;

using Microsoft.EntityFrameworkCore;
using KidzWorld.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GSMArena_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.KdzAges.OrderBy(x => Guid.NewGuid()).ToListAsync());
        }
        public async Task<IActionResult> ViewToyByAge(int? id)
        {
            var applicationDbContext = _context.KdzToys
            .Include(b => b.Ages).Where(m => m.AgeID== id);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ViewAllToys()
        {
            var applicationDbContext = _context.KdzToys.Include(p => p.Ages).Include(p => p.Sellers);
            return View(await applicationDbContext.ToListAsync());
        }

       public async Task<IActionResult> ViewRecipeID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.KdzToys
                .Include(b => b.Ages)
                .FirstOrDefaultAsync(m => m.AgeID== id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ViewSeller(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sllr = await _context.Sellers
                .Include(b => b.SellersToys)
                .Include(b => b.SellerReviews)
                .FirstOrDefaultAsync(m => m.SellerID == id);
            if (sllr == null)
            {
                return NotFound();
            }

            return View(sllr);
        }

        [Authorize]
        public IActionResult AddReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = _context.Sellers
                .FirstOrDefault(m => m.SellerID == id);
            if (seller == null)
            {
                return NotFound();
            }

            ViewData["SellerID"] = seller.SellerID;
            ViewData["SellerName"] = seller.SellerName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview([Bind("ReviewID,Rating,ReviewText,SellerID")] SellerReview sellerReview)
        {
            ModelState.Remove("ReviewDate");
            ModelState.Remove("UserID");
            if (ModelState.IsValid)
            {
                sellerReview.UserID = _userManager.GetUserName(this.User);
                sellerReview.ReviewDate = DateTime.Now;
                _context.Add(sellerReview);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyReviews));
        }

        [Authorize]
        public async Task<IActionResult> MyReviews()
        {
            string userid = _userManager.GetUserName(this.User);
            var reviews = _context.KdzSellerReview
                .Include(m => m.SellersReviews)
                .Where(m => m.UserID == userid);
            return View(await reviews.OrderByDescending(m => m.SellerID).ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
