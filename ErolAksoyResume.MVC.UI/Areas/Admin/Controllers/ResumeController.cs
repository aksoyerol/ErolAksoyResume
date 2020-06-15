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
        public ResumeController(IResumeService resumeService,IMapper mapper,ICategoryService categoryService,ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _mapper = mapper;
            _resumeService = resumeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<ResumeListDto>>(await _resumeService.GetListWithAllProp()));
        }

        public async Task<IActionResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id);

            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
            ResumeAddDto resumeAddDto = new ResumeAddDto();
            resumeAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            ViewBag.Sub = new SelectList(await _subCategoryService.GetListAsync(), "Id", "Name");
            return View(resumeAddDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ResumeAddDto resumeAddDto)
        {
            var starting = Convert.ToDateTime(resumeAddDto.StartedDate);
            var ending = Convert.ToDateTime(resumeAddDto.EndedDate);
            if (ModelState.IsValid)
            {
                await _resumeService.InsertAsync(new Resume
                {
                    Title = resumeAddDto.Title,
                    EndedDate = starting,
                    StartedDate = ending,
                    IsDraft = resumeAddDto.IsDraft,
                    SubCategoryId = resumeAddDto.SubCategoryId,
                    Text = resumeAddDto.Text


                });

            }

            return View(resumeAddDto);
        }
        
    }
}
