using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.Entity.Entities;

namespace PROJECT_IMDB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FilmController : Controller
    {
        private IFilmService _filmService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FilmController(IFilmService filmService, IWebHostEnvironment webHostEnvironment)
        {
            _filmService = filmService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _filmService.GetActive());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {

            string imageName = "noimage.png";
            if (film.ImageUpload != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/film");
                imageName = Guid.NewGuid().ToString() + "_" + film.ImageUpload.FileName;
                string filePath = Path.Combine(uploadDir, imageName);
                FileStream fs = new FileStream(filePath, FileMode.Create);
                await film.ImageUpload.CopyToAsync(fs);
                fs.Close();
                
            }
            film.Image = imageName;

            await _filmService.Add(film);
            return RedirectToAction("/Admin/Film/İndex");


        }
    }
}



