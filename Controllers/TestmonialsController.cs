using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TUITY_STORE.Models;

namespace TUITY_STORE.Controllers
{
    public class TestmonialsController : Controller
    {
        private readonly ModelContext _context;

        public TestmonialsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Testmonials
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Testmonials.Include(t => t.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Testmonials/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmonial = await _context.Testmonials
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testmonial == null)
            {
                return NotFound();
            }

            return View(testmonial);
        }

        // GET: Testmonials/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Userrs, "Id", "Id");
            return View();
        }

        // POST: Testmonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserMassege,UserId")] Testmonial testmonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testmonial);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserHome", "UserDashbord");
            }
            ViewData["UserId"] = new SelectList(_context.Userrs, "Id", "Id", testmonial.UserId);
            return View(testmonial);
        }

        // GET: Testmonials/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmonial = await _context.Testmonials.FindAsync(id);
            if (testmonial == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Userrs, "Id", "Id", testmonial.UserId);
            return View(testmonial);
        }

        // POST: Testmonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,UserMassege,UserId")] Testmonial testmonial)
        {
            if (id != testmonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testmonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestmonialExists(testmonial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("TestonialMasseges", "AdminDashbord");
            }
            ViewData["UserId"] = new SelectList(_context.Userrs, "Id", "Id", testmonial.UserId);
            return View(testmonial);
        }

        // GET: Testmonials/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmonial = await _context.Testmonials
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testmonial == null)
            {
                return NotFound();
            }

            return View(testmonial);
        }

        // POST: Testmonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var testmonial = await _context.Testmonials.FindAsync(id);
            _context.Testmonials.Remove(testmonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("TestonialMasseges", "AdminDashbord");
        }

        private bool TestmonialExists(decimal id)
        {
            return _context.Testmonials.Any(e => e.Id == id);
        }
    }
}
