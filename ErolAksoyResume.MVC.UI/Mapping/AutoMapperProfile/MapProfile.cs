using AutoMapper;
using ErolAksoyResume.Dto.Concrete.AppUserDtos;
using ErolAksoyResume.Dto.Concrete.BlogDtos;
using ErolAksoyResume.Dto.Concrete.CategoryDtos;

using ErolAksoyResume.Dto.Concrete.PortofolioDtos;
using ErolAksoyResume.Dto.Concrete.ProfileDtos;
using ErolAksoyResume.Dto.Concrete.ResumeDtos;
using ErolAksoyResume.Dto.Concrete.ServiceDtos;
using ErolAksoyResume.Dto.Concrete.SkillDtos;
using ErolAksoyResume.Dto.Concrete.SubCategoryDtos;
using ErolAksoyResume.Dto.Concrete.TestimionalDtos;
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
            CreateMap<Resume, ResumeUpdateDto>();
            CreateMap<ResumeUpdateDto, Resume>();

            CreateMap<AppUser, AppUserSignInDto>();
            CreateMap<AppUserSignInDto, AppUser>();

            CreateMap<Skill, SkillAddDto>();
            CreateMap<SkillAddDto, Skill>();
            CreateMap<Skill, SkillGeneralDto>();
            CreateMap<SkillGeneralDto, Skill>();

            CreateMap<Portofolio, PortofolioAddDto>();
            CreateMap<PortofolioAddDto, Portofolio>();
            CreateMap<Portofolio, PortofolioGeneralDto>();
            CreateMap<PortofolioGeneralDto, Portofolio>();

            CreateMap<Testimonial, TestimionalAddDto>();
            CreateMap<TestimionalAddDto, Testimonial>();
            CreateMap<Testimonial, TestimionalGeneralDto>();
            CreateMap<TestimionalGeneralDto, Testimonial>();

            CreateMap<Service, ServiceAddDto>();
            CreateMap<ServiceAddDto, Service>();
            CreateMap<Service, ServiceGeneralDto>();
            CreateMap<ServiceGeneralDto, Service>();

            CreateMap<Blog, BlogAddDto>();
            CreateMap<BlogAddDto, Blog>();
            CreateMap<Blog, BlogGeneralDto>();
            CreateMap<BlogGeneralDto, Blog>();

            CreateMap<AppUser, ProfileGeneralDto>();
            CreateMap<ProfileGeneralDto, AppUser>();
            CreateMap<AppUser, AppUserViewComponentDto>();
            CreateMap<AppUserViewComponentDto, AppUser>();


        }
    }
}
