using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Context;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryDal
    {
        public async Task<List<SubCategory>> GetSubCategoryWithCategoryAsync()
        {
            using var context = new MyContext();
            return await context.SubCategories.Include(x => x.Category).ToListAsync();
        }
    }
}

