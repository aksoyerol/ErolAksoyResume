using ErolAksoyResume.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class Skill : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LevelPercent { get; set; }
        public string Text { get; set; }
        public bool IsDraft { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
