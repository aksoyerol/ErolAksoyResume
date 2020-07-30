using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.ResumeDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public ResumeController(IResumeService resumeService, IMapper mapper, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _mapper = mapper;
            _resumeService = resumeService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "resume";
            //return View();
            return View(_mapper.Map<List<ResumeListDto>>(await _resumeService.GetListAsync()));
        }

        public async Task<IActionResult> GetSubCategories(int id)
        {

            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id);

            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        public IActionResult Create()
        {
            TempData["active"] = "resume";
            ResumeAddDto resumeAddDto = new ResumeAddDto();
            //resumeAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");

            return View(resumeAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResumeAddDto resumeAddDto)
        {

            if (ModelState.IsValid)
            {
                await _resumeService.InsertAsync(new Resume
                {
                    Title = resumeAddDto.Title,
                    EndedDate = resumeAddDto.StartedDate,
                    StartedDate = resumeAddDto.EndedDate,
                    IsDraft = resumeAddDto.IsDraft,
                    //SubCategoryId = resumeAddDto.SubCategoryId,
                    Text = resumeAddDto.Text,
                    IsEducation = resumeAddDto.IsEducation,
                    IsWork = resumeAddDto.IsWork


                });
                return RedirectToAction("Index");
            }
            //resumeAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");

            return View(resumeAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //var selectedCategory = _subCategoryService.GetByFilterAsync(x=>x.Category.SubCategories.)
            //_categoryService.GetWithAllProp(x=>x.Id == x.SubCategories.CategoryId)
            //TODO : Düzenleme ekranında kategori ve alt kategorilerin listelenmesi ve seçilmesi sağlanacak. 
            //Kategoriyi sub kategorilerle birlikte getirmeyi dene
            //var activeCategory = await _subCategoryService.GetSubCategoryWithCategoryAsync();
            //var category = activeCategory.Where(x => x.CategoryId == updatedResume.SubCategory.CategoryId).FirstOrDefault();

            var updatedResume = await _resumeService.GetByIdAsync(id);
            /*ar activecategory = await _categoryService.GetCategoryBySubCatIdAsync(updatedResume.SubCategoryId);*/
            //ViewBag.Deneme = activecategory.Name;
            //ViewBag.SubCatId = updatedResume.SubCategoryId;

            if (updatedResume != null)
            {
                //ViewBag.SubCategory = updatedResume.SubCategoryId;

                //resume.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activecategory.Id);
                //ViewBag.SubCatList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activecategory.Id),"Id","Name",updatedResume.SubCategoryId);
                return View(_mapper.Map<ResumeUpdateDto>(updatedResume));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResumeUpdateDto resumeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _resumeService.UpdateAsync(new Resume
                {
                    EndedDate = resumeUpdateDto.EndedDate,
                    Id = resumeUpdateDto.Id,
                    IsDraft = resumeUpdateDto.IsDraft,
                    StartedDate = resumeUpdateDto.StartedDate,
                    IsEducation = resumeUpdateDto.IsEducation,
                    IsWork = resumeUpdateDto.IsWork,
                    //SubCategoryId = resumeUpdateDto.SubCategoryId,
                    Text = resumeUpdateDto.Text,
                    Title = resumeUpdateDto.Title
                });

                return RedirectToAction("Index");
            }
            //var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(resumeUpdateDto.SubCategoryId);
            //resumeUpdateDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
            //ViewBag.SubCatList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", resumeUpdateDto.SubCategoryId);

            return View(resumeUpdateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedResume = await _resumeService.GetByIdAsync(id);
            if (deletedResume != null)
            {
                await _resumeService.DeleteAsync(deletedResume);
            }
            return Json(null);
        }
    }
}
