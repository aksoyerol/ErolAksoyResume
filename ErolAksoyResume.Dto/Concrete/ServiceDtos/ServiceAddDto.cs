using ErolAksoyResume.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.ServiceDtos
{
    public class ServiceAddDto : IDto
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
