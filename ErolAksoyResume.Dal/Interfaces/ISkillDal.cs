using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Interfaces
{
    public interface ISkillDal : IGenericDal<Skill>
    {
        Task<List<Skill>> GetListAllPropAsync();
    }
}
