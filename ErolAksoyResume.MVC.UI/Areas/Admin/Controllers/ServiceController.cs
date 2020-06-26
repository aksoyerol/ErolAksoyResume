using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.ServiceDtos;
using ErolAksoyResume.Entities.Concrete;
using ErolAksoyResume.MVC.UI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _mapper = mapper;
            _serviceService = serviceService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "service";
            return View(_mapper.Map<List<ServiceGeneralDto>>(await _serviceService.GetListAsync()));
        }

        public IActionResult Create()
        {
            TempData["active"] = "service";
            return View(new ServiceAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceAddDto serviceAddDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\service");
                    serviceAddDto.ImageUrl = imgName;
                }
                else
                {
                    serviceAddDto.ImageUrl = "no-photo.png";
                }
                await _serviceService.InsertAsync(new Service
                {
                    ImageUrl = serviceAddDto.ImageUrl,
                    Text = serviceAddDto.Text,
                    Title = serviceAddDto.Title
                });
                return RedirectToAction("Index");
            }
            return View(serviceAddDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["active"] = "service";
            var editedService = await _serviceService.GetByIdAsync(id);
            if (editedService != null)
            {
                return View(_mapper.Map<ServiceGeneralDto>(editedService));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceGeneralDto serviceGeneralDto, IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\service");
                    serviceGeneralDto.ImageUrl = imgName;
                }
                else
                {
                    var editedService = await _serviceService.GetByIdAsync(serviceGeneralDto.Id);
                    serviceGeneralDto.ImageUrl = editedService.ImageUrl;
                }

                await _serviceService.UpdateAsync(new Service
                {
                    ImageUrl = serviceGeneralDto.ImageUrl,
                    Id = serviceGeneralDto.Id,
                    Text = serviceGeneralDto.Text,
                    Title = serviceGeneralDto.Title
                });
                return RedirectToAction("Index");

            }
            return View(serviceGeneralDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedService = await _serviceService.GetByIdAsync(id);
            if (deletedService != null)
            {
                await _serviceService.DeleteAsync(deletedService);
            }
            return Json(null);
        }
    }
}
