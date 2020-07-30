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
using AutoMapper;
using ErolAksoyResume.Dto.Concrete.PortofolioDtos;
using ErolAksoyResume.Dto.Concrete.BlogDtos;

namespace ErolAksoyResume.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceService _serviceService;
        private readonly ISkillService _skillService;
        private readonly IAppUserService _appUserService;
        private readonly IResumeService _resumeService;
        private readonly ITestimionalService _testimionalService;
        private readonly IPortofolioService _portofolioService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public HomeController(UserManager<AppUser> userManager, IServiceService serviceService, ISkillService skillService, IAppUserService appUserService,
            IResumeService resumeService, ITestimionalService testimionalService, IPortofolioService portofolioService, ICategoryService categoryService,
            ISubCategoryService subCategoryService, IMapper mapper, IBlogService blogService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _portofolioService = portofolioService;
            _testimionalService = testimionalService;
            _resumeService = resumeService;
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


        public async Task<IActionResult> Resume([FromServices] ISubCategoryService subCategoryService)
        {

            //var educationSubCategory = await subCategoryService.GetByFilterAsync(x => x.Name == "Education" || x.Name == "Education History");
            //var workSubCategory = await subCategoryService.GetByFilterAsync(x => x.Name == "Work" || x.Name == "Working" || x.Name == "Works");
            //ResumePageModel resumePageModel = new ResumePageModel();
            //ViewBag.EducationSubCategoryId = educationSubCategory.Id;
            //ViewBag.WorkSubCategoryId = workSubCategory.Id;

            //resumePageModel.TestimonialList = await _testimionalService.GetListAsync();
            //resumePageModel.ResumeList = await _resumeService.GetListWithAllProp();

            return View();
        }

        public async Task<IActionResult> Portofolio()
        {
            PortofolioPageModel portofolioPageModel = new PortofolioPageModel();

            var portofolioSubCategory = await _subCategoryService.GetSubCategoryWithAllProp(x => x.Category.Name == "Portofolio");

            portofolioPageModel.SubCategoryList = portofolioSubCategory;
            portofolioPageModel.Portofolios = await _portofolioService.GetListWithAllPropAsync();

            return View(portofolioPageModel);
        }

        public async Task<IActionResult> PortofolioDetail(int id)
        {
            return View(_mapper.Map<PortofolioGeneralDto>(await _portofolioService.GetByIdAsync(id)));
        }

        //[AcceptVerbs("GET", "HEAD", Route = "{slug}")]
        public async Task<IActionResult> Blog(int? id)
        {
            var subCategoryControl = await _subCategoryService.GetByIdAsync(id.GetValueOrDefault());
            if (subCategoryControl!=null)
            {
                ViewData["BlogCategoryName"] = subCategoryControl.Name;
                return View(_mapper.Map<List<BlogGeneralDto>>(await _blogService.GetListWithAllPropByFilterAsync(x => x.SubCategoryId == id)));
            }
            return View(_mapper.Map<List<BlogGeneralDto>>(await _blogService.GetListWithAllPropAsync()));

        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog != null)
            {
                return View(_mapper.Map<BlogGeneralDto>(blog));
            }
            return NotFound();
        }

    }
}
