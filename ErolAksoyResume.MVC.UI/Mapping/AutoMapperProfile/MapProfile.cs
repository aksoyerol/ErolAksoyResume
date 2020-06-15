using AutoMapper;
using ErolAksoyResume.Dto.Concrete.CategoryDtos;
using ErolAksoyResume.Dto.Concrete.ResumeDtos;
using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
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
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();

            CreateMap<SubCategory, SubCategoryListDto>();
            CreateMap<SubCategoryListDto, SubCategory>();
            CreateMap<SubCategory, SubCategoryAddDto>();
            CreateMap<SubCategoryAddDto, SubCategory>();
            CreateMap<SubCategory, SubCategoryUpdateDto>();
            CreateMap<SubCategoryUpdateDto, SubCategory>();

            CreateMap<Resume, ResumeListDto>();
            CreateMap<ResumeListDto, Resume>();
            CreateMap<Resume, ResumeAddDto>();
            CreateMap<ResumeAddDto, Resume>();
        }
    }
}
