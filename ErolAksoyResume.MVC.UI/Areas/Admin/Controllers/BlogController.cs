using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.BlogDtos;
using ErolAksoyResume.Entities.Concrete;
using ErolAksoyResume.MVC.UI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(ICategoryService categoryService, ISubCategoryService subCategoryService, IBlogService blogService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _blogService = blogService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "blog";
            return View(_mapper.Map<List<BlogGeneralDto>>(await _blogService.GetListWithAllPropAsync()));
        }
        public async Task<JsonResult> GetSubCategories(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == id);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        public async Task<IActionResult> Create()
        {
            TempData["active"] = "blog";
            BlogAddDto blogAddDto = new BlogAddDto();
            blogAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", -1);
            return View(blogAddDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogAddDto blogAddDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\blog");
                    blogAddDto.ImageUrl = imgName;
                }
                else
                {
                    blogAddDto.ImageUrl = "no-photo.png";
                }

                await _blogService.InsertAsync(new Blog
                {
                    AppUserId = 1,
                    SubCategoryId = blogAddDto.SubCategoryId,
                    ImageUrl = blogAddDto.ImageUrl,
                    Text = blogAddDto.Text,
                    Title = blogAddDto.Title
                });
                return RedirectToAction("Index");
            }

            blogAddDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name");
            return View(blogAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["active"] = "blog";
            var editedBlog = await _blogService.GetByIdAsync(id);
            if (editedBlog != null)
            {
                var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(editedBlog.SubCategoryId);
                var blogGeneralDto = _mapper.Map<BlogGeneralDto>(editedBlog);
                blogGeneralDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
                blogGeneralDto.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", editedBlog.SubCategoryId);
                return View(blogGeneralDto);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogGeneralDto blogGeneralDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                var editedBlog = await _blogService.GetByIdAsync(blogGeneralDto.Id);
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\blog");
                    blogGeneralDto.ImageUrl = imgName;
                }
                else
                {
                    blogGeneralDto.ImageUrl = editedBlog.ImageUrl;
                }

                await _blogService.UpdateAsync(new Blog
                {
                    Id = blogGeneralDto.Id,
                    ImageUrl = blogGeneralDto.ImageUrl,
                    AppUserId = 1,
                    SubCategoryId = blogGeneralDto.SubCategoryId,
                    Text = blogGeneralDto.Text,
                    Title = blogGeneralDto.Title
                });
                return RedirectToAction("Index");
            }
            var activeCategory = await _categoryService.GetCategoryBySubCatIdAsync(blogGeneralDto.SubCategoryId);
            blogGeneralDto.CategoryList = new SelectList(await _categoryService.GetListAsync(), "Id", "Name", activeCategory.Id);
            blogGeneralDto.SubCategoryList = new SelectList(await _subCategoryService.GetListByFilterAsync(x => x.CategoryId == activeCategory.Id), "Id", "Name", blogGeneralDto.SubCategoryId);
            return View(blogGeneralDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedBlog = await _blogService.GetByIdAsync(id);
            if (deletedBlog != null)
            {
                await _blogService.DeleteAsync(deletedBlog);
            }
            return Json(null);
        }
    }
}
