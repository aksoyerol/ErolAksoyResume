using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ErolAksoyResume.MVC.UI.Models;
using Microsoft.AspNetCore.Identity;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Entities.Concrete;


namespace ErolAksoyResume.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceService _serviceService;
        private readonly ISkillService _skillService;
        private readonly IAppUserService _appUserService;
        public HomeController(UserManager<AppUser> userManager, IServiceService serviceService, ISkillService skillService, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _serviceService = serviceService;
            _skillService = skillService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _appUserService.GetByIdAsync(1);
            string userAbout = user.About;

            HomePageModel homePageModel = new HomePageModel();
            homePageModel.About = userAbout;
            homePageModel.ServiceList = await _serviceService.GetListAsync();
            homePageModel.SkillList = await _skillService.GetListAllPropAsync();
            
            return View(homePageModel);
        }

       
        public async Task<IActionResult> Resume()
        {
            return View();
        }
    }
}
