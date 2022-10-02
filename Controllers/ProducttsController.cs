using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TUITY_STORE.Models;

namespace TUITY_STORE.Controllers
{
    public class ProducttsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ProducttsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: Productts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Productts.Include(p => p.ProductCategory);
            return View(await modelContext.ToListAsync());
        }

        // GET: Productts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productt = await _context.Productts
                .Include(p => p.ProductCategory)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productt == null)
            {
                return NotFound();
            }

            return View(productt);
        }

        // GET: Productts/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "CategoryName");

            return View();
        }

        // POST: Productts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imagepath,Namee,Sale,Price,ProductCategoryId,ImageFile")] Productt productt)
        {
            if (ModelState.IsValid)
            {
                    if (productt.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + productt.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await productt.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        productt.Imagepath = ImageName;

                    }
                    _context.Add(productt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Products","AdminDashbord");
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "CategoryName", productt.ProductCategoryId);
            return View(productt);
        }

        // GET: Productts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productt = await _context.Productts.FindAsync(id);
            if (productt == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "CategoryName", productt.ProductCategoryId);

            return View(productt);
        }

        // POST: Productts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Imagepath,Namee,Sale,Price,ProductCategoryId,ImageFile")] Productt productt)
        {
            if (id != productt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (productt.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + productt.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await productt.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        productt.Imagepath = ImageName;

                    }
                    _context.Update(productt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducttExists(productt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Products", "AdminDashbord");
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "CategoryName", productt.ProductCategoryId);
            return View(productt);
        }

        // GET: Productts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productt = await _context.Productts
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productt == null)
            {
                return NotFound();
            }

            return View(productt);
        }

        // POST: Productts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var productt = await _context.Productts.FindAsync(id);
            _context.Productts.Remove(productt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Products", "AdminDashbord");
        }

        private bool ProducttExists(decimal id)
        {
            return _context.Productts.Any(e => e.Id == id);
        }
    }
}
