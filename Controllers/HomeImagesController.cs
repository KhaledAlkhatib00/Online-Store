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
    public class HomeImagesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public HomeImagesController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: HomeImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeImage.ToListAsync());
        }

        // GET: HomeImages/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // GET: HomeImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,ImagePath,ImageFile")] HomeImage homeImage)
        {
            if (ModelState.IsValid)
            {
                if (homeImage.ImageFile != null)
                {
                    // 1- path of w3rootfile
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    //2- imagename: using filename from imagefile proparty
                    // use Guid.NewGuid().Tostring to generate
                    string ImageName = Guid.NewGuid().ToString() + "_" + homeImage.ImageFile.FileName;
                    // 3- w3root/Image/imageName
                    string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                    //4- create image inside path
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await homeImage.ImageFile.CopyToAsync(filestream);
                    }
                    //5- store image path in DB
                    homeImage.ImagePath = ImageName;

                }
                _context.Add(homeImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeImage);
        }

        // GET: HomeImages/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage.FindAsync(id);
            if (homeImage == null)
            {
                return NotFound();
            }
            return View(homeImage);
        }

        // POST: HomeImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,name,ImagePath,ImageFile")] HomeImage homeImage)
        {
            if (id != homeImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (homeImage.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + homeImage.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await homeImage.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        homeImage.ImagePath = ImageName;

                    }
                    _context.Update(homeImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeImageExists(homeImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Home", "AdminDashbord");
            }
            return View(homeImage);
        }

        // GET: HomeImages/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeImage = await _context.HomeImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeImage == null)
            {
                return NotFound();
            }

            return View(homeImage);
        }

        // POST: HomeImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var homeImage = await _context.HomeImage.FindAsync(id);
            _context.HomeImage.Remove(homeImage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "AdminDashbord");
        }

        private bool HomeImageExists(decimal id)
        {
            return _context.HomeImage.Any(e => e.Id == id);
        }
    }
}
