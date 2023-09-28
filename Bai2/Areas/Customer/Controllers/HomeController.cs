using Bai2.Interfaces;
using Bai2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace Bai2.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageIndex = 1;

            if (page.HasValue)
            {
                pageIndex = page.Value;
            }

            var products = this.productService.FindAll();
            int totalPage = (int)Math.Ceiling((double)products.Count / pageSize);


            ViewBag.TOTAL_PAGE = totalPage;
            ViewBag.PAGE_INDEX = pageIndex;
            return View(products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        [HttpGet]
        public IActionResult Detail(int? productId)
        {
            if (!productId.HasValue)
            {
                return NotFound();
            }

            var product = this.productService.FindById(productId.Value);

            var categories = this.productService.FindAll().Where(x => x.CategoryId == product.CategoryId);
            ViewBag.CATEGORIES = categories;

            return View(product);
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
