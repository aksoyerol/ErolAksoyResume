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
    public class ResumeManager : GenericManager<Resume>, IResumeService
    {
        private readonly IResumeDal _resumeDal;
        public ResumeManager(IGenericDal<Resume> genericDal, IResumeDal resumeDal) : base(genericDal)
        {
            _resumeDal = resumeDal;
        }

        //public Task<List<Resume>> GetListWithAllProp()
        //{
        //    return _resumeDal.GetListWithAllProp();
        //}

        //public Task<Resume> GetSingleWithAllProp(Expression<Func<Resume, bool>> filter)
        //{
        //    return _resumeDal.GetSingleWithAllProp(filter);
        //}
    }
}
