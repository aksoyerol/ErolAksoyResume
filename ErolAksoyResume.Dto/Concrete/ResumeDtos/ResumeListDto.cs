using ErolAksoyResume.Dto.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.ResumeDtos
{
    public class ResumeListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public bool IsDraft { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
