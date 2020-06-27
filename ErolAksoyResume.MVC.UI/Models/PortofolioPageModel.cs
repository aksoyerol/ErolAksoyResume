using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Models
{
    public class PortofolioPageModel
    {
        public List<SubCategory> SubCategoryList { get; set; }
        public List<Portofolio> Portofolios { get; set; }
    }
}
