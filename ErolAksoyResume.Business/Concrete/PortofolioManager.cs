using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.Concrete
{
    public class PortofolioManager : GenericManager<Portofolio>,IPortofolioService
    {
        public PortofolioManager(IGenericDal<Portofolio> genericDal) : base(genericDal)
        {

        }
    }
}
