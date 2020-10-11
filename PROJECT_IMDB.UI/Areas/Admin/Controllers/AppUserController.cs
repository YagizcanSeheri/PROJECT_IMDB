using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.DAL.Context;
using PROJECT_IMDB.Entity.Entities;

namespace PROJECT_IMDB.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }


        public async Task<IActionResult> Index()
        {
            
             return View(await _appUserService.GetAll());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

       
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUser appUser) 
        {
            await _appUserService.Add(appUser);
            return RedirectToAction("/Admin/AppUser/Index");

        }


    }
}
