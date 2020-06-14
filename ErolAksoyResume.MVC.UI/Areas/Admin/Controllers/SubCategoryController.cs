using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public SubCategoryController(ISubCategoryService subCategoryService, IMapper mapper)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var subCategories = await _subCategoryService.GetSubCategoryWithCategoryAsync();
            return View(_mapper.Map<List<SubCategoryListDto>>(subCategories));
        }
    }
}
