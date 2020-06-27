using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Models
{
    public class ResumePageModel
    {
        public List<Resume> ResumeList { get; set; }
        public List<Testimonial> TestimonialList { get; set; }
    }
}
