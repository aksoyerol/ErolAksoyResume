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
            return View(_mapper.Map<List<SkillGeneralDto>>(await _skillService.GetListAllPropAsync()));
        }

        public JsonResult GetSubCategories(int id)
        {
            var list = _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id).Result;
            return Json(new SelectList(list, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
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
    }
}
