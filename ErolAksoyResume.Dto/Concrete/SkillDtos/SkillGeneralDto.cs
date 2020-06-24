using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.SkillDtos
{
    public class SkillGeneralDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LevelPercent { get; set; }
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList SubCategoryList { get; set; }
    }
}
