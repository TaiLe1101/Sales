using Bai2.Interfaces;
using Bai2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bai2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categries = categoryService.FindAll();
            return View(categries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Create(category);
                TempData["SUCCESS"] = "Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryService.FindById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(category);
                TempData["SUCCESS"] = "Updated successfuly";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { id = category.Id });

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            categoryService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
