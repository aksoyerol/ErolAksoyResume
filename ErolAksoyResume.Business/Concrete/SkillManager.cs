using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Concrete
{
    public class SkillManager : GenericManager<Skill>,ISkillService
    {
        private readonly ISkillDal _skillDal;
        public SkillManager(IGenericDal<Skill> genericDal,ISkillDal skillDal) : base(genericDal)
        {
            _skillDal = skillDal;
        }

        public Task<List<Skill>> GetListAllPropAsync()
        {
            return _skillDal.GetListAllPropAsync();
        }
    }
}
