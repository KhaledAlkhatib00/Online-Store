using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TUITY_STORE.Models;

namespace TUITY_STORE.Controllers
{
    public class AdminDashbordController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public AdminDashbordController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }


      

            public IActionResult Index()
        {
            return View();
        }


        public IActionResult Admin()
        {

            ViewBag.Numberofcustomer = _context.Logins.Where(x => x.Roleid == 1).Count();
            ViewBag.Numberofproduct = _context.Productts.Count();

            var totalsales = _context.OrderProducts.Include(x => x.Product).Include(x => x.Order).ToList();
            var x= totalsales.Select(x => x.Product.Price).Sum();
            var y= totalsales.Select(x => x.Quantity).Sum();

            ViewBag.TotalSales = x * y;

            ViewBag.MaxQuantiti = _context.OrderProducts.Max(x => x.Quantity);
            ViewBag.AdminID = _context.Logins.Where(x => x.Customerid == 1);
            ViewBag.OrderNumber = _context.Orderrs.Count();
            var customer = _context.Userrs.ToList();
            var userlogin = _context.Logins.Where(x => x.Roleid == 2).ToList();
            var role = _context.Rolees.ToList();
            var AdminInfo = from c in customer
                            join u in userlogin on c.Id equals u.Customerid
                            select new AdminsInfoJoin { User = c, Login = u };
            var productcategory = _context.ProductCategories.ToList();
            var model = Tuple.Create<IEnumerable<AdminsInfoJoin>, IEnumerable<ProductCategory>>(AdminInfo, productcategory);
            return View(model);

        }
        public IActionResult UserProfile()
        {
            ViewBag.userId = HttpContext.Session.GetInt32("AdminID");
            return RedirectToAction("Edit", "Userrs", new RouteValueDictionary(
            new { controller = "Userrs", action = "Edit", Id = ViewBag.userId }));
        }


        public IActionResult Users()
        {
            var user = _context.Userrs.ToList();
            var userlogin = _context.Logins.Where(x => x.Roleid == 1).ToList();


            var multiTable = from u in user
                             join l in userlogin on u.Id equals l.Customerid
                             select new UsersInfoJoin { login = l, user = u };

            return View(multiTable);
        }




        public IActionResult Stores()
        {
            var categoryes = _context.Categoryys.ToList();
            var store = _context.Storees.ToList();
            var storersinformation = from s in store
                             join c in categoryes on s.CategoryId equals c.Id
                             select new StoresDashbord { categoryy = c, store =s };

            return View(storersinformation);

        }

    
        public IActionResult Categorys()
        {
            var categorys = _context.ProductCategories.ToList();
            

            return View(categorys);

        }

     
        public IActionResult Products() {
            var product = _context.Productts.ToList();
            var store = _context.Storees.ToList().OrderBy(x => x.Id);
            var stpreProduct = _context.StorProducts.ToList().OrderBy(x => x.Id);
            var productCateogry = _context.ProductCategories.ToList();
            var productDitals = from s in store
                                join sp in stpreProduct on s.Id equals sp.StoreId
                                join p in product on sp.ProductId equals p.Id
                                join pc in productCateogry on p.ProductCategoryId equals pc.Id
                                select new ProductDitaels {  product= p, productCategory = pc ,storee=s,storProduct=sp};
            return View(productDitals);
        }

        public IActionResult AddProductToStore() {

            var storePrduct = _context.StorProducts.Include(x => x.Store).OrderBy(x => x.Id).Include(x => x.Product.ProductCategory).OrderBy(x=>x.Store.Id);
           
            return View(storePrduct);
        
         }   



        [HttpGet]
        public IActionResult OrdersTable()
        {
            var userLogin = _context.Logins.Where(x => x.Roleid == 1).ToList();
            var user = _context.Userrs.ToList();
            var order = _context.Orderrs.ToList();
            var orderProducts = _context.OrderProducts.ToList();
            var products = _context.Productts.ToList();
            var prductcategory = _context.ProductCategories.ToList();

            var multitable = from ul in userLogin
                             join u in user on ul.Customerid equals u.Id
                             join o in order on u.Id equals o.UserId
                             join op in orderProducts on o.Id equals op.OrderId
                             join p in products on op.ProductId equals p.Id
                             join pc in prductcategory on p.ProductCategoryId equals pc.Id
                             select new OrdersTable { userLogin = ul, order = o, orderProduct = op, productt = p, productCategory = pc };

            ViewBag.TotalQuantity = orderProducts.Sum(p => p.Quantity);

            var price = _context.Productts.Sum(x => x.Price);
            var Quantitys = _context.OrderProducts.Sum(p => p.Quantity);

            var result = _context.OrderProducts.Include(p => p.Product);
            ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);

            double profits = (int)ViewBag.TotalPrice * 0.25;
            ViewBag.Profits = profits;

            if (profits >= (int)ViewBag.TotalPrice * 0.25)
            {
                ViewBag.losses = profits * 0;
            }


            return View(multitable);
        }

        



        //httpget
        public IActionResult Search()
        {

            var result = _context.OrderProducts.Include(p => p.Product).Include(p => p.Order);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Search(DateTime? startDate, DateTime? endDate)
        {
            var result = _context.OrderProducts.Include(p => p.Product).Include(p => p.Order);

            if (startDate == null && endDate == null)
            {
                return View(result);
            }
            else if (startDate != null && endDate == null)
            {
                var data = await result.Where(x => x.Order.DATEFROM.Value.Date == startDate).ToListAsync();
                return View(data);
            }
            else if (startDate == null && endDate != null)
            {
                var data = await result.Where(x => x.Order.DATETO.Value.Date == endDate).ToListAsync();
                return View(data);
            }
            else
            {
                var data = await result.Where(x => x.Order.DATEFROM.Value.Date >= startDate && x.Order.DATETO.Value.Date <= endDate).ToListAsync();
                return View(data);
            }

        }

        //datatable :plug inb jquer to add interaction control to the html tables.

        //Report Method :

        [HttpGet]
        public IActionResult Report()
        {
            var userLogin = _context.Logins.Where(x => x.Roleid == 1).ToList();
            var user = _context.Userrs.ToList();
            var order = _context.Orderrs.ToList();
            var orderProducts = _context.OrderProducts.ToList();
            var products = _context.Productts.ToList();
            var prductcategory = _context.ProductCategories.ToList();

            var multitable = from ul in userLogin
                             join u in user on ul.Customerid equals u.Id
                             join o in order on u.Id equals o.UserId
                             join op in orderProducts on o.Id equals op.OrderId
                             join p in products on op.ProductId equals p.Id
                             join pc in prductcategory on p.ProductCategoryId equals pc.Id
                             select new ReportTable { userLogin = ul, order = o, orderProduct = op, productt = p, productCategory = pc };


            var result = _context.OrderProducts.Include(p => p.Product).Include(p => p.Order);
            ViewBag.TotalQuantity = result.Sum(p => p.Quantity);
            ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);
            double profits = (int)ViewBag.TotalPrice * 0.25;
            ViewBag.Profits = profits;

            if (profits >= (int)ViewBag.TotalPrice * 0.25)
            {
                ViewBag.losses = profits * 0;
            }

            var model = Tuple.Create<IEnumerable<OrderProduct>, IEnumerable<ReportTable>>(result, multitable);
            ViewBag.TotalQuantity = result.Sum(p => p.Quantity);
            ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Report(DateTime? startDate, DateTime? endDate)
        {
            var userLogin = _context.Logins.Where(x => x.Roleid == 1).ToList();
            var user = _context.Userrs.ToList();
            var order = _context.Orderrs.ToList();
            var orderProducts = _context.OrderProducts.ToList();
            var products = _context.Productts.ToList();
            var prductcategory = _context.ProductCategories.ToList();

            var multitable = from ul in userLogin
                             join u in user on ul.Customerid equals u.Id
                             join o in order on u.Id equals o.UserId
                             join op in orderProducts on o.Id equals op.OrderId
                             join p in products on op.ProductId equals p.Id
                             join pc in prductcategory on p.ProductCategoryId equals pc.Id
                             select new ReportTable { userLogin = ul, order = o, orderProduct = op, productt = p, productCategory = pc };


            var result = _context.OrderProducts.Include(p => p.Product).Include(p => p.Order);


            if (startDate == null && endDate == null)
            {
                ViewBag.TotalQuantity = result.Sum(p => p.Quantity);
                ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);
                var res = await result.ToListAsync();
                var model = Tuple.Create<IEnumerable<OrderProduct>, IEnumerable<ReportTable>>(res, multitable);
                return View(model);
            }
            else if (startDate != null && endDate == null)
            {
                ViewBag.TotalQuantity = result.Where(x => x.Order.DATEFROM.Value.Date == startDate).Sum(p => p.Quantity);
                ViewBag.TotalPrice = result.Where(x => x.Order.DATEFROM.Value.Date == startDate).Sum(p => p.Product.Price * p.Quantity);
                var data = await result.Where(x => x.Order.DATEFROM.Value.Date == startDate).ToListAsync();
                var model = Tuple.Create<IEnumerable<OrderProduct>, IEnumerable<ReportTable>>(data, multitable);

                return View(model);
            }
            else if (startDate == null && endDate != null)
            {
                ViewBag.TotalQuantity = result.Where(x => x.Order.DATETO.Value.Date == endDate).Sum(p => p.Quantity);
                ViewBag.TotalPrice = result.Where(x => x.Order.DATETO.Value.Date == endDate).Sum(p => p.Product.Price * p.Quantity);
                var data = await result.Where(x => x.Order.DATETO.Value.Date == endDate).ToListAsync();
                var model = Tuple.Create<IEnumerable<OrderProduct>, IEnumerable<ReportTable>>(data, multitable);
                return View(model);
            }
            else
            {
                ViewBag.TotalQuantity = result.Where(x => x.Order.DATEFROM.Value.Date >= startDate && x.Order.DATETO.Value.Date <= endDate).Sum(p => p.Quantity);
                ViewBag.TotalPrice = result.Where(x => x.Order.DATEFROM.Value.Date >= startDate && x.Order.DATETO.Value.Date <= endDate).Sum(p => p.Product.Price * p.Quantity);
                var data = await result.Where(x => x.Order.DATEFROM.Value.Date >= startDate && x.Order.DATETO.Value.Date <= endDate).ToListAsync();
                var model = Tuple.Create<IEnumerable<OrderProduct>, IEnumerable<ReportTable>>(data, multitable);
                return View(model);
            }

        }

        public IActionResult Massegies() {
            var massegies = _context.Contactus.ToList();
            return View(massegies);
        }

        public IActionResult Home() {

            var homeImages = _context.HomeImage.ToList();
            return View(homeImages);

        }
        public IActionResult About() {
            var aboutText = _context.Aboutus.ToList();
            return View(aboutText);
        }



        public IActionResult TestonialMasseges() {

            var testemonial = _context.Testmonials.Where(x=>x.Id!=1).ToList();
            var users = _context.Userrs.ToList();
            var test_emonialTable = from t in testemonial
                                    join u in users on t.UserId equals u.Id
                                    select new Test_emonial { testmonial = t, user = u };

            return View(test_emonialTable);
        }




        public IActionResult SendEmail()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendEmail(TUITY_STORE.Models.Gmail model, string To,string Body)
        {
            MailMessage mm = new MailMessage("Khaledalkhatib11@outlook.com", To);

            mm.Subject = "Invoice";
            mm.Body = Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;


            NetworkCredential nc = new NetworkCredential("Khaledalkhatib11@outlook.com", "Khaled@Noor@189@134");
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sent Succsesful";


            return RedirectToAction("OrdersTable", "AdminDashbord");
        }


    }

}
