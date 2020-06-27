using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Models
{
    public class HomePageModel
    {
        public string About { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Skill> SkillList { get; set; }
    }
}
