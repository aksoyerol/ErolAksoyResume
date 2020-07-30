using AutoMapper;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dto.Concrete.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.ViewComponents
{
    public class ProfileNavbarViewComponent : ViewComponent
    {
        private IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public ProfileNavbarViewComponent(IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _appUserService.GetByFilterAsync(x => x.Id == 1 && x.UserName == "pcparticle");
            return View(_mapper.Map<AppUserViewComponentDto>(user));
        }

    }

}
