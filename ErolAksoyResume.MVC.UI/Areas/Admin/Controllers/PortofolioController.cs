using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.PortofolioDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortofolioController : Controller
    {
        private readonly IPortofolioService _portofolioService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        
        public PortofolioController(IPortofolioService portofolioService, ICategoryService categoryService,
            ISubCategoryService subCategoryService, IMapper mapper)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _portofolioService = portofolioService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<PortofolioGeneralDto>>(await _portofolioService.GetListAsync()));
        }

        public async Task<JsonResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
            PortofolioAddDto portofolioAddDto = new PortofolioAddDto();
            portofolioAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(portofolioAddDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PortofolioAddDto portofolioAddDto, IFormFile imgFile,[FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null && (imgFile.ContentType == "image/jpg" || imgFile.ContentType == "image/png" || imgFile.ContentType == "image/jpeg"))
                {
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath+"/img/portofolio");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    var imgExtension = Path.GetExtension(imgFile.FileName);
                    string imgName = Guid.NewGuid().ToString() + imgExtension;
                    
                    
                   
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/portofolio/" + imgName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imgFile.CopyToAsync(stream);
                    }
                    portofolioAddDto.ImageUrl = imgName;

                }

                await _portofolioService.InsertAsync(new Portofolio
                {
                    SubCategoryId = portofolioAddDto.SubCategoryId,
                    Text = portofolioAddDto.Text,
                    Title = portofolioAddDto.Title,
                    ImageUrl = portofolioAddDto.ImageUrl
                });

                return RedirectToAction("Index");

            }
            portofolioAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(portofolioAddDto);
        }
    }
}
