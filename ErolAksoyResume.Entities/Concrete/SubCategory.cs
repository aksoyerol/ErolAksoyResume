using ErolAksoyResume.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class SubCategory : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Portofolio> Portofolios { get; set; }
    }
}
