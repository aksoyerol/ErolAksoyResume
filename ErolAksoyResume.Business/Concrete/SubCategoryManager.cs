using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Business.Concrete
{

    public class SubCategoryManager : GenericManager<SubCategory>, ISubCategoryService
    {
        private readonly ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(IGenericDal<SubCategory> genericDal, ISubCategoryDal subCategoryDal) : base(genericDal)
        {
            _subCategoryDal = subCategoryDal;
            //if (_subCategoryDal.GetByFilterAsync(x => x.Name == "Work").Result == null)
            //{

            //    _subCategoryDal.InsertAsync(new SubCategory
            //    {
            //        Id = 544,
            //        Name = "Work",
            //        CategoryId = 1007
            //    }).Wait();
            //}
        }


        public async Task<List<SubCategory>> GetSubCategoryWithAllProp(Expression<Func<SubCategory, bool>> filter)
        {
            return await _subCategoryDal.GetSubCategoryWithAllProp(filter);
        }

        public async Task<List<SubCategory>> GetSubCategoryWithCategoryAsync()
        {
            return await _subCategoryDal.GetSubCategoryWithCategoryAsync();
        }
    }
}
