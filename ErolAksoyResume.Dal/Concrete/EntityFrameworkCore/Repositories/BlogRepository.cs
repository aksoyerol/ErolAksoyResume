﻿using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Context;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetListWithAllPropAsync()
        {
            using var context = new MyContext();
            return await context.Blogs.Include(x => x.AppUser).Include(x => x.SubCategory).ToListAsync();
        }
    }
}
