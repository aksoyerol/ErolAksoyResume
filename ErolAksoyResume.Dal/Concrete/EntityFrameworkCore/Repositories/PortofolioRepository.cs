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
    public class PortofolioRepository : GenericRepository<Portofolio>, IPortofolioDal
    {
        public async Task<List<Portofolio>> GetListWithAllPropAsync()
        {
            using var context = new MyContext();
            return await context.Portofolios.Include(x => x.SubCategory).ToListAsync();
        }
    }
}
