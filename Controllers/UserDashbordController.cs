using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UserDashbordController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public UserDashbordController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;

        }



        public IActionResult UserHome()
        {
            ViewBag.userId = HttpContext.Session.GetInt32("CustomerID");

            var category = _context.Categoryys.ToList();
            var stores = _context.Storees.ToList();
            var storeProduct = _context.StorProducts.ToList();
            var product = _context.Productts.ToList();
            var productCategory = _context.ProductCategories.ToList();

            var HomeInformation = from c in category
                                  join s in stores on c.Id equals s.CategoryId
                                  join sp in storeProduct on s.Id equals sp.StoreId
                                  join p in product on sp.ProductId equals p.Id
                                  join pc in productCategory on p.ProductCategoryId equals pc.Id
                                  select new UserHomeTable { categoryy = c, storee = s, storproduct = sp, product = p, productcategory = pc };

            var ImageWelcome = _context.HomeImage.ToList();
            var testemonial = _context.Testmonials.ToList();
            var users = _context.Userrs.ToList();
            var test_emonialTable = from t in testemonial
                                    join u in users on t.UserId equals u.Id
                                    select new Test_emonial { testmonial = t, user = u };


            var model = Tuple.Create<IEnumerable<UserHomeTable>, IEnumerable<HomeImage>,IEnumerable<Test_emonial>>(HomeInformation, ImageWelcome,test_emonialTable);
            return View(model);

        }

        public IActionResult Stores()
        {
            var AllStore = _context.Storees.ToList();
            return View(AllStore);

        }
        public IActionResult AdidasStore()
        {
            var store = _context.Storees.Where(x => x.Id == 1).ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.ToList();
            var adidasProduct = from s in store
                                join a in adidas on s.Id equals a.StoreId
                                join ap in product on a.ProductId equals ap.Id
                                select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(adidasProduct);

        }
        
        public IActionResult NikeStore()
        {
            var store = _context.Storees.Where(x => x.Id == 2).ToList();
            var nike = _context.StorProducts.ToList();
            var product = _context.Productts.ToList();
            var NikeProduct = from s in store
                              join n in nike on s.Id equals n.StoreId
                              join ap in product on n.ProductId equals ap.Id
                              select new StoresPrductTable { store = s, storProduct = n, productt = ap };
            return View(NikeProduct);

        }
        
        public IActionResult IrbedStore()
        {

            var store = _context.Storees.Where(x => x.Id == 22).ToList();
            var irbed = _context.StorProducts.ToList();
            var product = _context.Productts.ToList();
            var irbedProduct = from s in store
                               join i in irbed on s.Id equals i.StoreId
                               join ap in product on i.ProductId equals ap.Id
                               select new StoresPrductTable { store = s, storProduct = i, productt = ap };
            return View(irbedProduct);

        }
        
        public IActionResult AlkhatibStore()
        {
            var store = _context.Storees.Where(x => x.Id == 21).ToList();
            var clothes = _context.StorProducts.ToList();
            var product = _context.Productts.ToList();
            var alkhatibStore = from s in store
                                join c in clothes on s.Id equals c.StoreId
                                join ap in product on c.ProductId equals ap.Id
                                select new StoresPrductTable { store = s, storProduct = c, productt = ap };
            var model = Tuple.Create<IEnumerable<StoresPrductTable>>(alkhatibStore);

            return View(alkhatibStore);

        }

        // Categoryes  PERFUME  ACCESSORY  SPORT   DRESS  SUITS    HOMECLOTHES    BABY      SHOES

        public IActionResult PERFUME() {
            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x=>x.ProductCategoryId==21).ToList();
            var perfum = from s in store
                                join a in adidas on s.Id equals a.StoreId
                                join ap in product on a.ProductId equals ap.Id
                                select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(perfum);
        }

        public IActionResult ACCESSORY() {
            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 23).ToList();
            var acss = from s in store
                         join a in adidas on s.Id equals a.StoreId
                         join ap in product on a.ProductId equals ap.Id
                         select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(acss);
        }
        public IActionResult SPORT() {
            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 65).ToList();
            var sport = from s in store
                       join a in adidas on s.Id equals a.StoreId
                       join ap in product on a.ProductId equals ap.Id
                       select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(sport);
        }
        public IActionResult DRESS() {

            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 61).ToList();
            var dress = from s in store
                        join a in adidas on s.Id equals a.StoreId
                        join ap in product on a.ProductId equals ap.Id
                        select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(dress);
        }
        public IActionResult SUITS() {

            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 62).ToList();
            var dress = from s in store
                        join a in adidas on s.Id equals a.StoreId
                        join ap in product on a.ProductId equals ap.Id
                        select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(dress);
        }
        public IActionResult HOMECLOTHES() {

            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 63).ToList();
            var dress = from s in store
                        join a in adidas on s.Id equals a.StoreId
                        join ap in product on a.ProductId equals ap.Id
                        select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(dress);
        }
        public IActionResult BABY() {

            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 64).ToList();
            var dress = from s in store
                        join a in adidas on s.Id equals a.StoreId
                        join ap in product on a.ProductId equals ap.Id
                        select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(dress);
        }
        public IActionResult SHOES() {

            var store = _context.Storees.ToList();
            var adidas = _context.StorProducts.ToList();
            var product = _context.Productts.Where(x => x.ProductCategoryId == 66).ToList();
            var dress = from s in store
                        join a in adidas on s.Id equals a.StoreId
                        join ap in product on a.ProductId equals ap.Id
                        select new StoresPrductTable { store = s, storProduct = a, productt = ap };


            return View(dress);
        }
       
   

        //End OF Category



        public IActionResult Account()
        {
            ViewBag.userId = HttpContext.Session.GetInt32("CustomerID");
            return RedirectToAction("Edit", "Userrs", new RouteValueDictionary(
            new { controller = "Userrs", action = "Edit", Id = ViewBag.userId }));
            

        }

        public IActionResult UserContact() {
          
            ViewBag.userId = HttpContext.Session.GetInt32("CustomerID");
            return RedirectToAction("Create", "Contactus");
        }

        public IActionResult Testemonial()
        {


            ViewBag.idTestemonial = HttpContext.Session.GetInt32("CustomerID");
            return RedirectToAction("Create", "Testmonials");

        }

        



        public IActionResult AddToCart()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([Bind("Id,UserId,DATEFROM,DATETO")] Orderr orderr,int quantiti,int productId)
        {
            if (ModelState.IsValid)
            {
                orderr.UserId=HttpContext.Session.GetInt32("CustomerID");
                orderr.DATEFROM = DateTime.Today;
                orderr.DATETO = DateTime.Today;
                _context.Add(orderr);
                await _context.SaveChangesAsync();
                var lastid = orderr.Id;
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.OrderId = lastid;
                orderProduct.ProductId= productId;
                orderProduct.Quantity = quantiti;
                _context.Add(orderProduct);
                await _context.SaveChangesAsync();


                return RedirectToAction("Cart", "UserDashbord");
            }

            return View();
        }



        public IActionResult Cart()
        {
            var UserId= HttpContext.Session.GetInt32("CustomerID");


            var userLogin = _context.Logins.Where(x => x.Roleid == 1).ToList();
            var user = _context.Userrs.Where(x=>x.Id==UserId).ToList();
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
                             select new UserOrders { userLogin = ul, order = o, orderProduct = op, productt = p, productCategory = pc };
             ViewBag.TotalQuantity = orderProducts.Where(x=>x.Order.UserId==UserId).Sum(p => p.Quantity);

            var price = _context.Productts.Sum(x => x.Price);

            var Quantitys = _context.OrderProducts.Where(x=>x.Order.UserId==UserId).Sum(p => p.Quantity);

            var result = _context.OrderProducts.Include(p => p.Product).Include(x=>x.Order).Where(x=>x.Order.UserId==UserId);

            ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);

           


            return View(multitable);
        }


        public IActionResult CheekOut()
        {
            var UserId = HttpContext.Session.GetInt32("CustomerID");


            var userLogin = _context.Logins.Where(x => x.Roleid == 1).ToList();
            var user = _context.Userrs.Where(x => x.Id == UserId).ToList();
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
                             select new UserOrders { userLogin = ul, order = o, orderProduct = op, productt = p, productCategory = pc };
            ViewBag.TotalQuantity = orderProducts.Where(x => x.Order.UserId == UserId).Sum(p => p.Quantity);

            var price = _context.Productts.Sum(x => x.Price);

            var Quantitys = _context.OrderProducts.Where(x => x.Order.UserId == UserId).Sum(p => p.Quantity);

            var result = _context.OrderProducts.Include(p => p.Product).Include(x => x.Order).Where(x => x.Order.UserId == UserId);

            ViewBag.TotalPrice = result.Sum(p => p.Product.Price * p.Quantity);


            var bankAccount = _context.BankAccounts.ToList();
            var accountCheek = from u in user
                               join ba in bankAccount on u.Id equals ba.CustomerId
                               select new Pay { userr = u, bankAccount = ba };

            var model = Tuple.Create<IEnumerable<UserOrders>, IEnumerable<Pay>>(multitable, accountCheek);



            return View(model);
        }



        public IActionResult VerifyBankAccount()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyBankAccount([Bind("Id,AccountNumber,AccountSnn,CustomerId")]BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                var CustomerId= HttpContext.Session.GetInt32("CustomerID");
                bankAccount.CustomerId = CustomerId;
                _context.Add(bankAccount);
                await _context.SaveChangesAsync();



                return RedirectToAction("Cart", "UserDashbord");
            }

            return View(bankAccount);
        }







    }
}
