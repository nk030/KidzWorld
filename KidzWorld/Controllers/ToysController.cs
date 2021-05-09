using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidzWorld.Data;
using KidzWorld.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace KidzWorld.Controllers
{
    [Authorize(Roles = "admin")]
    public class ToysController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ToysController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KdzToys.Include(p => p.Ages).Include(p=>p.Sellers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Toys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.KdzToys
                .Include(p => p.Ages)
                .FirstOrDefaultAsync(m => m.ToyID == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // GET: Toys/Create
        public IActionResult Create()
        {
            ViewData["AgeID"] = new SelectList(_context.KdzAges, "AgeID", "AgeName");
            ViewData["SellerID"] = new SelectList(_context.Sellers, "SellerID", "SellerName");

            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToyID,ToyName,Price,ToyDescription,File,AgeID,SellerID")] Toys toys)
        {
            using (var memoryStream = new MemoryStream())
            {
                await toys.File.FormFile.CopyToAsync(memoryStream);

                string photoname = toys.File.FormFile.FileName;
                toys.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(toys.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(toys);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "product_images");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = toys.ToyID + toys.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await toys.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgeID"] = new SelectList(_context.KdzAges, "AgeID", "AgeName", toys.AgeID);
            ViewData["SellerID"] = new SelectList(_context.Sellers, "SellerID", "SellerName");
            return View(toys);
        }

        // GET: Toys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.KdzToys.FindAsync(id);
            if (toys == null)
            {
                return NotFound();
            }
            ViewData["AgeID"] = new SelectList(_context.KdzAges, "AgeID", "AgeName", toys.AgeID);
            return View(toys);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToyID,ToyName,Price,ToyDescription,Extension,AgeID,SellerID")] Toys toys)
        {
            if (id != toys.ToyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToysExists(toys.ToyID))
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
            ViewData["AgeID"] = new SelectList(_context.KdzAges, "AgeID", "AgeName", toys.AgeID);
            ViewData["SellerID"] = new SelectList(_context.Sellers, "SellerID", "SellerName");

            return View(toys);
        }

        // GET: Toys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await _context.KdzToys
                .Include(p => p.Ages)
                .FirstOrDefaultAsync(m => m.ToyID == id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toys = await _context.KdzToys.FindAsync(id);
            _context.KdzToys.Remove(toys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToysExists(int id)
        {
            return _context.KdzToys.Any(e => e.ToyID == id);
        }
    }
}
