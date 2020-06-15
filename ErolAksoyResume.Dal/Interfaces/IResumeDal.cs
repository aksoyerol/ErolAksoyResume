using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Interfaces
{
    public interface IResumeDal : IGenericDal<Resume>
    {
        Task<List<Resume>> GetListWithAllProp();
    }
}
