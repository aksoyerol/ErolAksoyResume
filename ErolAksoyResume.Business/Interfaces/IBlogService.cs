using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Interfaces
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetListWithAllPropAsync();
        Task<List<Blog>> GetListWithAllPropByFilterAsync(Expression<Func<Blog, bool>> filter);
    }
}
