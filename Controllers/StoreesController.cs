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
    public class StoreesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public StoreesController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: Storees
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Storees.Include(s => s.Category);
            return View(await modelContext.ToListAsync());
        }

        // GET: Storees/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storee = await _context.Storees
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storee == null)
            {
                return NotFound();
            }

            return View(storee);
        }

        // GET: Storees/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categoryys, "Id", "CategoryyName");
            return View();
        }

        // POST: Storees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StoreName,CategoryId,ImageFile")] Storee storee)
        {
            if (ModelState.IsValid)
            {
                if (storee.ImageFile != null)
                {
                    // 1- path of w3rootfile
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    //2- imagename: using filename from imagefile proparty
                    // use Guid.NewGuid().Tostring to generate
                    string ImageName = Guid.NewGuid().ToString() + "_" + storee.ImageFile.FileName;
                    // 3- w3root/Image/imageName
                    string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                    //4- create image inside path
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await storee.ImageFile.CopyToAsync(filestream);
                    }
                    //5- store image path in DB
                    storee.ImagePath = ImageName;

                }
                _context.Add(storee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Stores", "AdminDashbord");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categoryys, "Id", "CategoryyName", storee.CategoryId);
            return View(storee);
        }

        // GET: Storees/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storee = await _context.Storees.FindAsync(id);
            if (storee == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categoryys, "Id", "CategoryyName", storee.CategoryId);
            return View(storee);
        }

        // POST: Storees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,StoreName,CategoryId,ImageFile")] Storee storee)
        {
            if (id != storee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (storee.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + storee.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await storee.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        storee.ImagePath = ImageName;

                    }
                    _context.Update(storee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreeExists(storee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Stores", "AdminDashbord");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categoryys, "Id", "CategoryyName", storee.CategoryId);
            return View(storee);
        }

        // GET: Storees/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storee = await _context.Storees
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storee == null)
            {
                return NotFound();
            }

            return View(storee);
        }

        // POST: Storees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var storee = await _context.Storees.FindAsync(id);
            _context.Storees.Remove(storee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Stores", "AdminDashbord");
        }

        private bool StoreeExists(decimal id)
        {
            return _context.Storees.Any(e => e.Id == id);
        }
    }
}
