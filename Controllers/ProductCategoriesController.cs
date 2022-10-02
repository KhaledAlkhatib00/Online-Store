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
    public class ProductCategoriesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public ProductCategoriesController(ModelContext context, IWebHostEnvironment webHostEnviroment
)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategories.ToListAsync());
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,ImageFile")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                if (productCategory.ImageFile != null)
                {
                    // 1- path of w3rootfile
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    //2- imagename: using filename from imagefile proparty
                    // use Guid.NewGuid().Tostring to generate
                    string ImageName = Guid.NewGuid().ToString() + "_" + productCategory.ImageFile.FileName;
                    // 3- w3root/Image/imageName
                    string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                    //4- create image inside path
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await productCategory.ImageFile.CopyToAsync(filestream);
                    }
                    //5- store image path in DB
                    productCategory.ImagePath = ImageName;

                }
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Categorys", "AdminDashbord");

            }
            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,CategoryName,ImageFile")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (productCategory.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + productCategory.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await productCategory.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        productCategory.ImagePath = ImageName;

                    }
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Categorys", "AdminDashbord");
        }

        private bool ProductCategoryExists(decimal id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
