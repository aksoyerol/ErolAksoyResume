using ErolAksoyResume.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.AppUserDtos
{
    public class AppUserSignInDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
