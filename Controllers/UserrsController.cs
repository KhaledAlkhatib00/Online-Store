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
    public class UserrsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public UserrsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }

        // GET: Userrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userrs.ToListAsync());
        }

        // GET: Userrs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // GET: Userrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname,Email,PhoneNum,Imagepath,ImageFile")] Userr userr)
        {
            if (ModelState.IsValid)
            {
                if (userr.ImageFile != null)
                {
                    // 1- path of w3rootfile
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    //2- imagename: using filename from imagefile proparty
                    // use Guid.NewGuid().Tostring to generate
                    string ImageName = Guid.NewGuid().ToString() + "_" + userr.ImageFile.FileName;
                    // 3- w3root/Image/imageName
                    string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                    //4- create image inside path
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await userr.ImageFile.CopyToAsync(filestream);
                    }
                    //5- store image path in DB
                    userr.Imagepath = ImageName;

                }
                _context.Add(userr);
                await _context.SaveChangesAsync();
                return RedirectToAction("Users", "AdminDashbord");
            }
            return View(userr);
        }

        // GET: Userrs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs.FindAsync(id);
            if (userr == null)
            {
                return NotFound();
            }
            return View(userr);
        }

        // POST: Userrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Fname,Lname,Email,PhoneNum,Imagepath,ImageFile")] Userr userr)
        {
            if (id != userr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (userr.ImageFile != null)
                    {
                        // 1- path of w3rootfile
                        string w3rootpath = _webHostEnviroment.WebRootPath;
                        //2- imagename: using filename from imagefile proparty
                        // use Guid.NewGuid().Tostring to generate
                        string ImageName = Guid.NewGuid().ToString() + "_" + userr.ImageFile.FileName;
                        // 3- w3root/Image/imageName
                        string path = Path.Combine(w3rootpath + "/Image/" + ImageName);
                        //4- create image inside path
                        using (var filestream = new FileStream(path, FileMode.Create))
                        {
                            await userr.ImageFile.CopyToAsync(filestream);
                        }
                        //5- store image path in DB
                        userr.Imagepath = ImageName;

                    }
                    _context.Update(userr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserrExists(userr.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (userr.Id == 1)
                {

                    return RedirectToAction("Admin", "AdminDashbord");
                }
                else {

                    return RedirectToAction("UserHome", "UserDashbord");
                }
            }
            return View(userr);
        }

        // GET: Userrs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userr = await _context.Userrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userr == null)
            {
                return NotFound();
            }

            return View(userr);
        }

        // POST: Userrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var userr = await _context.Userrs.FindAsync(id);
            _context.Userrs.Remove(userr);
            await _context.SaveChangesAsync();
            return RedirectToAction("Users", "AdminDashbord");
        }

        private bool UserrExists(decimal id)
        {
            return _context.Userrs.Any(e => e.Id == id);
        }
    }
}
