using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TUITY_STORE.Models;

namespace TUITY_STORE.Controllers
{
    public class LoginRegisterController : Controller
    {
         private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public LoginRegisterController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Fname,Lname,Email,PhoneNum,ImagePath,ImageFile")] Userr customer, string password, string username)
        {
            if (ModelState.IsValid)
            {
                if (customer.ImageFile != null)
                {
                    string w3rootpath = _webHostEnviroment.WebRootPath;
                    string imageName = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName;
                    string path = Path.Combine(w3rootpath + "/Image/" + imageName);

                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await customer.ImageFile.CopyToAsync(filestream);
                    }

                    customer.Imagepath = imageName;
                }

                _context.Add(customer);
                await _context.SaveChangesAsync();

                var lastid = customer.Id;
                Login userLogin = new Login();
                userLogin.Passwordd = password;
                userLogin.UserName = username;
                userLogin.Customerid = lastid;
                userLogin.Roleid = 1;
                _context.Add(userLogin);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "LoginRegister");
            }
            return View(customer);
        }


        public IActionResult Login()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Login([Bind("UserName,Passwordd")] Login Login)
        {

           
            var auth = _context.Logins.Where(x => x.UserName == Login.UserName && x.Passwordd == Login.Passwordd).SingleOrDefault();
           

            if (auth != null)
            {

                switch (auth.Roleid)
                {
                    case 1:
                        HttpContext.Session.SetInt32("CustomerID", (int)auth.Customerid);
                        TempData["User_ID"] = (int)auth.Customerid;

                        return RedirectToAction("UserHome", "UserDashbord");
                    
                    case 2:
                        HttpContext.Session.SetInt32("AdminID", (int)auth.Customerid);
                        TempData["User_ID"] = (int)auth.Customerid;
                        return RedirectToAction("Admin", "AdminDashbord");


                }
            }
            return View();
        }

        


    }
}
