using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.ViewComponents
{
    public class BlogCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public BlogCategoryViewComponent(ICategoryService categoryService, ISubCategoryService subCategoryService, IMapper mapper)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = await _categoryService.GetByFilterAsync(x => x.Name == "Blog");
            var blogCategory = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == category.Id);
            return View(_mapper.Map<List<SubCategoryListDto>>(blogCategory));
        }
    }
}
