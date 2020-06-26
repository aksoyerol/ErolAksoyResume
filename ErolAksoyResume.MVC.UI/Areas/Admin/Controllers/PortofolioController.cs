using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.PortofolioDtos;
using ErolAksoyResume.Entities.Concrete;
using ErolAksoyResume.MVC.UI.Helpers;
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
            TempData["active"] = "portofolio";
            return View(_mapper.Map<List<PortofolioGeneralDto>>(await _portofolioService.GetListWithAllPropAsync()));
        }

        public async Task<JsonResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
            TempData["active"] = "portofolio";
            PortofolioAddDto portofolioAddDto = new PortofolioAddDto();
            portofolioAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(portofolioAddDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PortofolioAddDto portofolioAddDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    var imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\portofolio");
                    portofolioAddDto.ImageUrl = imgName;
                }
                else
                {
                    portofolioAddDto.ImageUrl = "no-image.png";
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

        public async Task<IActionResult> Edit(int id)
        {
            TempData["active"] = "portofolio";
            var editedPortofolio = await _portofolioService.GetByIdAsync(id);
            if (editedPortofolio != null)
            {
                var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(editedPortofolio.SubCategoryId);

                var portofolio = _mapper.Map<PortofolioGeneralDto>(editedPortofolio);
                portofolio.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
                portofolio.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", editedPortofolio.SubCategoryId);
                return View(portofolio);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PortofolioGeneralDto portofolioGeneralDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null /*&& (imgFile.ContentType == "image/jpg" || imgFile.ContentType == "image/png" || imgFile.ContentType == "image/jpeg")*/)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\portofolio");
                    portofolioGeneralDto.ImageUrl = imgName;
                }
                else
                {
                    var updatedPortofolioForImageUrl = await _portofolioService.GetByIdAsync(portofolioGeneralDto.Id);
                    portofolioGeneralDto.ImageUrl = updatedPortofolioForImageUrl.ImageUrl;
                }


                await _portofolioService.UpdateAsync(new Portofolio
                {
                    Id = portofolioGeneralDto.Id,
                    ImageUrl = portofolioGeneralDto.ImageUrl,
                    SubCategoryId = portofolioGeneralDto.SubCategoryId,
                    Text = portofolioGeneralDto.Text,
                    Title = portofolioGeneralDto.Title
                });
                return RedirectToAction("Index");
            }
            var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(portofolioGeneralDto.SubCategoryId);
            portofolioGeneralDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
            portofolioGeneralDto.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", portofolioGeneralDto.SubCategoryId);

            return View(portofolioGeneralDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedPortofilo = await _portofolioService.GetByIdAsync(id);
            if (deletedPortofilo != null)
            {
                await _portofolioService.DeleteAsync(deletedPortofilo);
                return Json(null);
            }
            return NotFound();
        }


    }


}
