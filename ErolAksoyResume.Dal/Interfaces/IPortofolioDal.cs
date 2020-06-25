using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Interfaces
{
    public interface IPortofolioDal : IGenericDal<Portofolio>
    {
        Task<List<Portofolio>> GetListWithAllPropAsync();
    }
}
