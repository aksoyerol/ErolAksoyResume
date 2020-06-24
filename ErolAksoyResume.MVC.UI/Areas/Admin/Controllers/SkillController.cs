using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.SkillDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ICategoryService categoryService, ISubCategoryService subCategoryService, ISkillService skillService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = "skill";
            return View(_mapper.Map<List<SkillGeneralDto>>(await _skillService.GetListAllPropAsync()));
        }

        public JsonResult GetSubCategories(int id)
        {
            var list = _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id).Result;
            return Json(new SelectList(list, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
            TempData["active"] = "skill";
            SkillAddDto skillAddDto = new SkillAddDto();
            skillAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(skillAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillAddDto skillAddDto)
        {
            if (ModelState.IsValid)
            {
                await _skillService.InsertAsync(new Skill
                {
                    IsDraft = skillAddDto.IsDraft,
                    LevelPercent = skillAddDto.LevelPercent,
                    SubCategoryId = skillAddDto.SubCategoryId,
                    Text = skillAddDto.Text,
                    Title = skillAddDto.Title,

                });

                return RedirectToAction("Index");
            }

            skillAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(skillAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["active"] = "skill";
            var updatedSkill = await _skillService.GetByIdAsync(id);
            var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(updatedSkill.SubCategoryId);
            if (updatedSkill != null)
            {
                var skill = _mapper.Map<SkillGeneralDto>(updatedSkill);
                skill.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
                skill.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", updatedSkill.SubCategoryId);

                return View(skill);

            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillGeneralDto skillGeneralDto)
        {
            var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(skillGeneralDto.SubCategoryId);
            if (ModelState.IsValid)
            {
                await _skillService.UpdateAsync(new Skill
                {
                    Id = skillGeneralDto.Id,
                    IsDraft = skillGeneralDto.IsDraft,
                    LevelPercent = skillGeneralDto.LevelPercent,
                    SubCategoryId = skillGeneralDto.SubCategoryId,
                    Text = skillGeneralDto.Text,
                    Title = skillGeneralDto.Title

                });
                return RedirectToAction("Index");
            }
            skillGeneralDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
            skillGeneralDto.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", skillGeneralDto.SubCategoryId);
            return View(skillGeneralDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedSkill = await _skillService.GetByIdAsync(id);
            if (deletedSkill != null)
            {
                await _skillService.DeleteAsync(deletedSkill);
            }
            return Json(null);
        }

    }
}
