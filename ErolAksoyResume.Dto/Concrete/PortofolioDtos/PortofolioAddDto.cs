using ErolAksoyResume.Dto.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.PortofolioDtos
{
    public class PortofolioAddDto : IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public SelectList CategoryList { get; set; }

    }
}
