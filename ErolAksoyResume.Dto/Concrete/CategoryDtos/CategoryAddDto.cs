using ErolAksoyResume.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }
    }
}
