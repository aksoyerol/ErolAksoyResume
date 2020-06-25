using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Interfaces
{
    public interface IPortofolioService : IGenericService<Portofolio>
    {
        Task<List<Portofolio>> GetListWithAllPropAsync();
    }
}
