using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErolAksoyResume.Dto.Concrete.AppUserDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Controllers
{
    public class SignInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public SignInController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home",new { area = "Admin"});
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or pass");
                }
                
            }

            return View(model);

        }
    }
}
