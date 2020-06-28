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
    public class BlogManager : GenericManager<Blog>,IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal,IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;
        }

        public Task<List<Blog>> GetListWithAllPropAsync()
        {
            return _blogDal.GetListWithAllPropAsync();
        }

        public Task<List<Blog>> GetListWithAllPropByFilterAsync(Expression<Func<Blog, bool>> filter)
        {
            return _blogDal.GetListWithAllPropByFilterAsync(filter);
        }
    }
}
