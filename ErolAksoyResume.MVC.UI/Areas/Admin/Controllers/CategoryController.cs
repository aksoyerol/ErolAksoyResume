using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetListAsync()));
        }
    }
}
