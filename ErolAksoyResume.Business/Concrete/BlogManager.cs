using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>,IBlogService
    {
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {

        }
    }
}
