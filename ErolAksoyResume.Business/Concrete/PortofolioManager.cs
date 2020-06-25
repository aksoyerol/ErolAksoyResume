using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Concrete
{
    public class PortofolioManager : GenericManager<Portofolio>,IPortofolioService
    {
        private readonly IPortofolioDal _portofolioDal;
        public PortofolioManager(IGenericDal<Portofolio> genericDal, IPortofolioDal portofolioDal) : base(genericDal)
        {
            _portofolioDal = portofolioDal;
        }

        public Task<List<Portofolio>> GetListWithAllPropAsync()
        {
            return _portofolioDal.GetListWithAllPropAsync();
        }
    }
}
