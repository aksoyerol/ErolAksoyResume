using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public SubCategoryController(ISubCategoryService subCategoryService, IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var subCategories = await _subCategoryService.GetSubCategoryWithCategoryAsync();
            return View(_mapper.Map<List<SubCategoryListDto>>(subCategories));
        }

        public async Task<IActionResult> Create()
        {
            SubCategoryAddDto subCategoryAddDto = new SubCategoryAddDto();
            subCategoryAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(subCategoryAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryAddDto subCategoryAddDto)
        {
            if (ModelState.IsValid)
            {
                await _subCategoryService.InsertAsync(new SubCategory
                {
                    Name = subCategoryAddDto.Name,
                    CategoryId = subCategoryAddDto.CategoryId
                });

                return RedirectToAction("Index", "SubCategory");
            }
            subCategoryAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(subCategoryAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var editingSubCategory = await _subCategoryService.GetByIdAsync(id);
            if (editingSubCategory != null)
            {

                var subCategory = _mapper.Map<SubCategoryUpdateDto>(editingSubCategory);

                subCategory.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", id);

                return View(subCategory);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubCategoryUpdateDto subCategoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _subCategoryService.UpdateAsync(new SubCategory
                {
                    Id = subCategoryUpdateDto.Id,
                    Name = subCategoryUpdateDto.Name,
                    CategoryId = subCategoryUpdateDto.CategoryId,
                });
                return RedirectToAction("Index", "SubCategory");
            }
            subCategoryUpdateDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", subCategoryUpdateDto.CategoryId);

            return View(subCategoryUpdateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var deletedSubCategory = await _subCategoryService.GetByIdAsync(id);
            if (deletedSubCategory != null)
            {
                await _subCategoryService.DeleteAsync(deletedSubCategory);
            }
            return Json(null);
        }
    }
}
