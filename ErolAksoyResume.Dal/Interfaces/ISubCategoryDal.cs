using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Interfaces
{
    public interface ISubCategoryDal : IGenericDal<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoryWithCategoryAsync();
    }
}
