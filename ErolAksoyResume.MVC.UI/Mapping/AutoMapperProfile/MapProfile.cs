using AutoMapper;
using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryListDto, Category>();
        }
    }
}
