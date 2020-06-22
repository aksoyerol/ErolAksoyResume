using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<Category> GetWithAllProp(Expression<Func<Category,bool>> filter);

        Task<Category> GetCategoryBySubCatIdAsync(int id);
    }
}
