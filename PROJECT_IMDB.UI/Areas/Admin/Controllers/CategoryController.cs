using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.Entity.Entities;

namespace PROJECT_IMDB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) 
        {
            Category category = await _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
                TempData["message"] = "Category is Uptated";
                return RedirectToAction("Index");
            }
            else
                return View("Category", category);
        }

        public async Task<IActionResult> Delete(int id) 
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }
        
    }
}
