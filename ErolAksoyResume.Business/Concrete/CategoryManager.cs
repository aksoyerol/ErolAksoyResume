using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>,ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Category> GetWithAllProp(Expression<Func<Category, bool>> filter)
        {
            return await _categoryDal.GetWithAllProp(filter);
        }

        public async Task<Category> GetWithSubCatAsync()
        {
            return await _categoryDal.GetWithSubCatAsync();
        }
    }
}
