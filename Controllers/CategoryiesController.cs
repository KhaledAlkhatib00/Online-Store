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
    public class CategoryiesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public CategoryiesController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: Categoryies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoryys.ToListAsync());
        }

        // GET: Categoryies/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryy = await _context.Categoryys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryy == null)
            {
                return NotFound();
            }

            return View(categoryy);
        }

        // GET: Categoryies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoryies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryyName,ImagePath,ImageFile")] Categoryy categoryy)
        {
            if (ModelState.IsValid)
            {
                if (categoryy.ImageFile != null)
                {
                    // 1- path of w3rootfile
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    //2- imagename: using filename from imagefile proparty
                    // use Guid.NewGuid().Tostring to generate
                    string ImageName = Guid.NewGuid().ToString() + "_" + categoryy.ImageFile.FileName;
                    // 3- w3root/Image/imageName
                    string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                    //4- create image inside path
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await categoryy.ImageFile.CopyToAsync(filestream);
                    }
                    //5- store image path in DB
                    categoryy.ImagePath = ImageName;

                }
                _context.Add(categoryy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Categorys", "AdminDashbord");
            }
            return View(categoryy);
        }

        // GET: Categoryies/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryy = await _context.Categoryys.FindAsync(id);
            if (categoryy == null)
            {
                return NotFound();
            }
            return View(categoryy);
        }

        // POST: Categoryies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,CategoryyName,ImagePath,ImageFile")] Categoryy categoryy)
        {
            if (id != categoryy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categoryy.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + categoryy.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await categoryy.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        categoryy.ImagePath = ImageName;

                    }
                    _context.Update(categoryy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryyExists(categoryy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Categorys", "AdminDashbord");
            }
            return View(categoryy);
        }

        // GET: Categoryies/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryy = await _context.Categoryys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryy == null)
            {
                return NotFound();
            }

            return View(categoryy);
        }

        // POST: Categoryies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categoryy = await _context.Categoryys.FindAsync(id);
            _context.Categoryys.Remove(categoryy);
            await _context.SaveChangesAsync();
            return RedirectToAction("Categorys", "AdminDashbord");
        }

        private bool CategoryyExists(decimal id)
        {
            return _context.Categoryys.Any(e => e.Id == id);
        }
    }
}
