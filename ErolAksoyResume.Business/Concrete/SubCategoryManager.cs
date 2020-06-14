using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.Concrete
{
    public class SubCategoryManager : GenericManager<SubCategory>,ISubCategoryService
    {
        public SubCategoryManager(IGenericDal<SubCategory> genericDal) : base(genericDal)
        {

        }
    }
}
