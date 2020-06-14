using ErolAksoyResume.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
