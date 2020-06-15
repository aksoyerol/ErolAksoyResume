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
    public class ResumeRepository : GenericRepository<Resume>, IResumeDal
    {
        public async Task<List<Resume>> GetListWithAllProp()
        {
            using var context = new MyContext();
            return await context.Resumes.Include(x => x.SubCategory).ToListAsync();
        }
    }
}
