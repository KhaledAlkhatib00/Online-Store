using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TUITY_STORE.Models;

namespace TUITY_STORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly ModelContext _context;

        public HomeController(ILogger<HomeController> logger, ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _logger = logger;

            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        public IActionResult Index()
        {
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


            var model = Tuple.Create<IEnumerable<UserHomeTable>, IEnumerable<HomeImage>, IEnumerable<Test_emonial>>(HomeInformation, ImageWelcome, test_emonialTable);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
