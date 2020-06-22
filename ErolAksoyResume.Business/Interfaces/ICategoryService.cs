using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category> GetWithAllProp(Expression<Func<Category, bool>> filter);
        Task<Category> GetCategoryBySubCatIdAsync(int id);
    }
}
