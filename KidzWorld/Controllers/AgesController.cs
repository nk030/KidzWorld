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
    [Authorize(Roles ="admin")]
    public class AgesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ages
        public async Task<IActionResult> Index()
        {
            return View(await _context.KdzAges.ToListAsync());
        }

        // GET: Ages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var age = await _context.KdzAges
                .FirstOrDefaultAsync(m => m.AgeID == id);
            if (age == null)
            {
                return NotFound();
            }

            return View(age);
        }

        // GET: Ages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgeID,AgeName")] Age age)
        {
            if (ModelState.IsValid)
            {
                _context.Add(age);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(age);
        }

        // GET: Ages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var age = await _context.KdzAges.FindAsync(id);
            if (age == null)
            {
                return NotFound();
            }
            return View(age);
        }

        // POST: Ages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgeID,AgeName")] Age age)
        {
            if (id != age.AgeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(age);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgeExists(age.AgeID))
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
            return View(age);
        }

        // GET: Ages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var age = await _context.KdzAges
                .FirstOrDefaultAsync(m => m.AgeID == id);
            if (age == null)
            {
                return NotFound();
            }

            return View(age);
        }

        // POST: Ages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var age = await _context.KdzAges.FindAsync(id);
            _context.KdzAges.Remove(age);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgeExists(int id)
        {
            return _context.KdzAges.Any(e => e.AgeID == id);
        }
    }
}
