using Bai2.Common;
using Bai2.Interfaces;
using Bai2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Bai2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = page.HasValue ? page.Value : 1;

            var products = productService.FindAll();

            int totalPage = (int)Math.Ceiling((double)products.Count / pageSize);

            ViewBag.TOTAL_PAGE = totalPage;
            ViewBag.PAGE_INDEX = pageIndex;
            return View(products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {

            var products = productService.FindAll();
            return Json(new { data = products.ToList() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            ViewBag.CATEGORIES = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product payload, IFormFile fileImage)
        {
            if (!ModelState.IsValid)
            {
                var categories = categoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.CATEGORIES = categories;
                return View();
            }

            payload.ImageUrl = new HandleFile("images/products").Save(fileImage);
            productService.Create(payload);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (!id.HasValue)
            {
                return NotFound();
            }

            var product = productService.FindById(id.Value);

            var categories = categoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.CATEGORIES = categories;
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product payload, IFormFile fileImage)
        {
            if (!ModelState.IsValid)
            {
                var categories = categoryService.FindAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                ViewBag.CATEGORIES = categories;
                return View();
            }

            if (fileImage != null)
            {
                if (!string.IsNullOrEmpty(payload.ImageUrl))
                {
                    new HandleFile("images/products").Delete(payload.ImageUrl.Split("/").Last());
                }
                payload.ImageUrl = new HandleFile("images/products").Save(fileImage);
            }

            productService.Update(payload);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false });
            }

            productService.DeleteById(id.Value);
            return Json(new { Success = true });
        }
    }
}
