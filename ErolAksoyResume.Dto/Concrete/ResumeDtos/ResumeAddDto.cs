using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.ResumeDtos
{
    public class ResumeAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public bool IsDraft { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
