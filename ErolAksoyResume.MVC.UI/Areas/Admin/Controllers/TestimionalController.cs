using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.TestimionalDtos;
using ErolAksoyResume.Entities.Concrete;
using ErolAksoyResume.MVC.UI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimionalController : Controller
    {
        private readonly ITestimionalService _testimionalService;
        private readonly IMapper _mapper;
        public TestimionalController(ITestimionalService testimionalService, IMapper mapper)
        {
            _mapper = mapper;
            _testimionalService = testimionalService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "testimional";
            return View(_mapper.Map<List<TestimionalGeneralDto>>(await _testimionalService.GetListAsync()));
        }

        public IActionResult Create()
        {
            TempData["active"] = "testimional";
            return View(new TestimionalAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestimionalAddDto testimionalAddDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\testimonial");
                    testimionalAddDto.ImageUrl = imgName;
                }

                await _testimionalService.InsertAsync(new Testimonial
                {
                    IsDraft = testimionalAddDto.IsDraft,
                    Name = testimionalAddDto.Name,
                    Text = testimionalAddDto.Text,
                    Title = testimionalAddDto.Title,
                    ImageUrl = testimionalAddDto.ImageUrl

                });
                return RedirectToAction("Index");
            }
            return View(testimionalAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["active"] = "testimional";
            var updatedTestimonial = await _testimionalService.GetByIdAsync(id);
            if (updatedTestimonial != null)
            {
                return View(_mapper.Map<TestimionalGeneralDto>(updatedTestimonial));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TestimionalGeneralDto testimionalGeneralDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\testimonial");
                    testimionalGeneralDto.ImageUrl = imgName;
                }
                else
                {
                    var editedTestimional = await _testimionalService.GetByIdAsync(testimionalGeneralDto.Id);
                    testimionalGeneralDto.ImageUrl = editedTestimional.ImageUrl;
                }
                await _testimionalService.UpdateAsync(new Testimonial
                {
                    Id = testimionalGeneralDto.Id,
                    ImageUrl = testimionalGeneralDto.ImageUrl,
                    IsDraft = testimionalGeneralDto.IsDraft,
                    Name = testimionalGeneralDto.Name,
                    Text = testimionalGeneralDto.Text,
                    Title = testimionalGeneralDto.Title
                });

                return RedirectToAction("Index");
            }
            return View(testimionalGeneralDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedTestimonial = await _testimionalService.GetByIdAsync(id);
            if (deletedTestimonial != null)
            {
                await _testimionalService.DeleteAsync(deletedTestimonial);
            }
            return Json(null);
        }
    }
}
