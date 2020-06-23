using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            TempData["active"] = "profile";
            return View();
        }
    }
}
