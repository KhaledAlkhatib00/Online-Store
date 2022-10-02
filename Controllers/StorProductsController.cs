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
    public class StorProductsController : Controller
    {
        private readonly ModelContext _context;

        public StorProductsController(ModelContext context)
        {
            _context = context;
        }

        // GET: StorProducts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.StorProducts.Include(s => s.Product).Include(s => s.Store);
            return View(await modelContext.ToListAsync());
        }

        // GET: StorProducts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storProduct = await _context.StorProducts
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storProduct == null)
            {
                return NotFound();
            }

            return View(storProduct);
        }

        // GET: StorProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Productts, "Id", "Namee");
            ViewData["StoreId"] = new SelectList(_context.Storees, "Id", "StoreName");
            return View();
        }

        // POST: StorProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StoreName,ProductId,StoreId")] StorProduct storProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddProductToStore", "AdminDashbord");
            }
            ViewData["ProductId"] = new SelectList(_context.Productts, "Id", "Namee", storProduct.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Storees, "Id", "StoreName", storProduct.StoreId);
            return View(storProduct);
        }

        // GET: StorProducts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storProduct = await _context.StorProducts.FindAsync(id);
            if (storProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Productts, "Id", "Namee", storProduct.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Storees, "Id", "StoreName", storProduct.StoreId);
            return View(storProduct);
        }

        // POST: StorProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,StoreName,ProductId,StoreId")] StorProduct storProduct)
        {
            if (id != storProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorProductExists(storProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AddProductToStore", "AdminDashbord");
            }
            ViewData["ProductId"] = new SelectList(_context.Productts, "Id", "Namee", storProduct.ProductId);
            ViewData["StoreId"] = new SelectList(_context.Storees, "Id", "StoreName", storProduct.StoreId);
            return View(storProduct);
        }

        // GET: StorProducts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storProduct = await _context.StorProducts
                .Include(s => s.Product)
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storProduct == null)
            {
                return NotFound();
            }

            return View(storProduct);
        }

        // POST: StorProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var storProduct = await _context.StorProducts.FindAsync(id);
            _context.StorProducts.Remove(storProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddProductToStore", "AdminDashbord");
        }

        private bool StorProductExists(decimal id)
        {
            return _context.StorProducts.Any(e => e.Id == id);
        }
    }
}
