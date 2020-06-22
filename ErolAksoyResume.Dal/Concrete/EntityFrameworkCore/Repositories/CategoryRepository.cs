using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Context;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public async Task<Category> GetWithAllProp(Expression<Func<Category, bool>> filter)
        {
            using var context = new MyContext();
            return await context.Categories.Include(x => x.SubCategories).Where(filter).FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoryBySubCatIdAsync(int id)
        {
            using var context = new MyContext();
            return await context.Categories.Join(context.SubCategories, category => category.Id, subCategory => subCategory.CategoryId, (categoryResult, subCategoryResult) => new
            {
                category = categoryResult,
                subCategory = subCategoryResult

            }).Where(x => x.subCategory.Id == id).Select(x => new Category
            {
                Id = x.category.Id,
                Name = x.category.Name
            }).FirstOrDefaultAsync();
        }
    }
}

