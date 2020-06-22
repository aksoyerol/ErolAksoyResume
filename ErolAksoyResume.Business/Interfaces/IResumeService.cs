using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Interfaces
{
    public interface IResumeService : IGenericService<Resume>
    {
        Task<List<Resume>> GetListWithAllProp();
        Task<Resume> GetSingleWithAllProp(Expression<Func<Resume, bool>> filter);
    }
}
