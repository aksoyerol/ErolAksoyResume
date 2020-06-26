using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.ProfileDtos;
using ErolAksoyResume.Entities.Concrete;
using ErolAksoyResume.MVC.UI.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        public ProfileController(IMapper mapper, UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

            TempData["active"] = "profile";
            return View(_mapper.Map<ProfileGeneralDto>(await _appUserService.GetByIdAsync(activeUser.Id)));
        }

        [HttpPost]
        public async Task<IActionResult> PhotoUpload(IFormFile imgFile, [FromServices] IWebHostEnvironment webHostEnvironment, ProfileGeneralDto profileGeneralDto)
        {
            if (ModelState.IsValid)
            {
                var activeUser = await _appUserService.GetByIdAsync(profileGeneralDto.Id);
                if (imgFile != null)
                {
                    string imgName = await ImageUploadHelper.ImageUploadAsync(webHostEnvironment, imgFile, "\\img\\profile");
                    profileGeneralDto.ProfileImageUrl = imgName;
                    activeUser.ProfileImageUrl = profileGeneralDto.ProfileImageUrl;
                }
                //else
                //{
                //    profileGeneralDto.ProfileImageUrl = activeUser.ProfileImageUrl;
                //}
                //activeUser.ProfileImageUrl = profileGeneralDto.ProfileImageUrl;

                await _appUserService.UpdateAsync(activeUser);

                return RedirectToAction("Index");
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileGeneralDto profileGeneralDto)
        {
            var user = await _userManager.FindByIdAsync(profileGeneralDto.Id.ToString());
            if (ModelState.IsValid)
            {
              
                user.Instagram = profileGeneralDto.Instagram;
                user.LastName = profileGeneralDto.LastName;
                user.Github = profileGeneralDto.Github;
                user.Twitter = profileGeneralDto.Twitter;
                user.LinkedIn = profileGeneralDto.LinkedIn;
                user.Name = profileGeneralDto.Name;
                user.Adress = profileGeneralDto.Adress;
                user.Email = profileGeneralDto.Email;
                user.Medium = profileGeneralDto.Medium;
                user.Phone = profileGeneralDto.Phone;
                user.About = profileGeneralDto.About;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("Index", profileGeneralDto);
        }

    }
}
