using AutoMapper;
using ErolAksoyResume.Dto.Concrete.AppUserDtos;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Areas.Admin.ViewComponents
{
    public class ProfileInfo : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ProfileInfo(UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = _mapper.Map<AppUserSignInDto>(activeUser);

            return View(model);

        }

    }
}
