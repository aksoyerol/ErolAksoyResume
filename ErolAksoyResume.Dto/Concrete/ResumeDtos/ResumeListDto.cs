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
        public string StartedDate { get; set; }
        public string EndedDate { get; set; }
        public bool IsDraft { get; set; }
        public bool IsWork { get; set; }
        public bool IsEducation { get; set; }
        //public SubCategory SubCategory { get; set; }
    }
}
