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

        [HttpGet]
        public async Task<IActionResult> Update(int id) 
        {
            AppUser appUser = await _appUserService.GetById(id);
            return View(appUser);
            
            
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AppUser appUser) 
        {
            if (ModelState.IsValid)
            {
               
               await _appUserService.Update(appUser);
                TempData["message"] = "User is Uptated";
                return RedirectToAction("Index");
            }
            else
            {
                return View("AppUser", appUser);
            }
            
        }
        public async Task<IActionResult> Delete(int id) 
        {
            await _appUserService.Remove(id);
            return RedirectToAction("Index");
        }


    }
}
