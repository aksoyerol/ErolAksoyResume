using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.SubCategoryDtos
{
    public class SubCategoryAddDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
