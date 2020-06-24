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
    public class SkillRepository : GenericRepository<Skill>, ISkillDal
    {
        public async Task<List<Skill>> GetListAllPropAsync()
        {
            using var context = new MyContext();
            return await context.Skills.Include(x => x.SubCategory).ToListAsync();
        }
    }
}
