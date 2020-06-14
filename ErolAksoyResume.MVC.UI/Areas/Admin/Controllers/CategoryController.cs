using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetListAsync()));
        }

        public IActionResult Create()
        {
            return View(new CategoryAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.InsertAsync(new Category
                {
                    Name = categoryAddDto.Name
                });
                return RedirectToAction("Index", "Category");
            }
            return View(categoryAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                return View(_mapper.Map<CategoryUpdateDto>(category));
            }
            return BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(new Category
                {
                    Id = categoryUpdateDto.Id,
                    Name = categoryUpdateDto.Name
                });
                return RedirectToAction("Index", "Category");
            }
            return View(categoryUpdateDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = await _categoryService.GetByIdAsync(id);
            if (deletedCategory != null)
            {
                await _categoryService.DeleteAsync(deletedCategory);
            }

            return Json(null);
        }

    }
}
