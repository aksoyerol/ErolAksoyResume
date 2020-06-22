using ErolAksoyResume.Dto.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.ResumeDtos
{
    public class ResumeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string StartedDate { get; set; }
        public string EndedDate { get; set; }
        public bool IsDraft { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
