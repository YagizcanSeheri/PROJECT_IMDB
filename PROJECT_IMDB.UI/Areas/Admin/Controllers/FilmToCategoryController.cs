using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROJECT_IMBD.Service.Services.Concrete;
using PROJECT_IMDB.DAL.Context;
using PROJECT_IMDB.Entity.Entities;

namespace PROJECT_IMDB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FilmToCategoryController : Controller
    {
        private readonly ProjectContext _context;
       
        public FilmToCategoryController(ProjectContext projectContext)
        {
            _context = projectContext;
            
        }
        public IActionResult Index()
        {
            return View( _context.FilmToCategories.Where(x=> x.Status != Status.Passive).ToList());
        }

        public IActionResult FilmToCategoriesAdd()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.Where(x => x.Status != Status.Passive), "Id", "Name");
            ViewBag.FilmId = new SelectList(_context.Films.Where(x => x.Status != Status.Passive), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult FilmToCategoriesAdd(FilmToCategory data)
        {
            _context.Add(data);
            _context.SaveChanges();
            return View();
        }
    }
}
