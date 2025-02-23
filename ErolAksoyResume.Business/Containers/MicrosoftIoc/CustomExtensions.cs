﻿using ErolAksoyResume.Business.Concrete;
using ErolAksoyResume.Business.Interfaces;
using ErolAksoyResume.Business.ValidationRules.FluentValidation;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.AppUserDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.BlogDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.PortofolioDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.ProfileDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.ResumeDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.ServiceDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.SkillDtoValidator;
using ErolAksoyResume.Business.ValidationRules.FluentValidation.TestimionalDtoValidator;
using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories;
using ErolAksoyResume.Dal.Interfaces;
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
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Business.Containers.MicrosoftIoc
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped<IAppUserDal, AppUserRepository>();
            services.AddScoped<IBlogDal, BlogRepository>();
            services.AddScoped<ICategoryDal, CategoryRepository>();
            services.AddScoped<IPortofolioDal, PortofolioRepository>();
            services.AddScoped<IResumeDal, ResumeRepository>();
            services.AddScoped<IServiceDal, ServiceRepository>();
            services.AddScoped<ISkillDal, SkillRepository>();
            services.AddScoped<ISubCategoryDal, SubCategoryRepository>();
            services.AddScoped<ITestimionalDal, TestimionalRepository>();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IPortofolioService, PortofolioManager>();
            services.AddScoped<IResumeService, ResumeManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISubCategoryService, SubCategoryManager>();
            services.AddScoped<ITestimionalService, TestimionalManager>();

            /************************** VALIDATON **************************/

            services.AddTransient<IValidator<CategoryListDto>, CategoryListDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            services.AddTransient<IValidator<SubCategoryAddDto>, SubCategoryAddDtoValidator>();
            services.AddTransient<IValidator<SubCategoryUpdateDto>, SubCategoryUpdateDtoValidator>();
            services.AddTransient<IValidator<ResumeAddDto>, ResumeAddDtoValidator>();
            services.AddTransient<IValidator<ResumeUpdateDto>, ResumeUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInDtoValidator>();
            services.AddTransient<IValidator<SkillAddDto>, SkillAddDtoValidator>();
            services.AddTransient<IValidator<SkillGeneralDto>, SkillGeneralDtoValidator>();
            services.AddTransient<IValidator<PortofolioAddDto>, PortofolioAddDtoValidator>();
            services.AddTransient<IValidator<PortofolioGeneralDto>, PortofolioGeneralDtoValidator>();
            services.AddTransient<IValidator<TestimionalAddDto>, TestimionalAddDtoValidator>();
            services.AddTransient<IValidator<TestimionalGeneralDto>, TestimionalGeneralDtoValidator>();
            services.AddTransient<IValidator<ServiceAddDto>, ServiceAddDtoValidator>();
            services.AddTransient<IValidator<ServiceGeneralDto>, ServiceGeneralDtoValidator>();
            services.AddTransient<IValidator<BlogAddDto>, BlogAddDtoValidator>();
            services.AddTransient<IValidator<BlogGeneralDto>, BlogGeneralDtoValidator>();
            services.AddTransient<IValidator<ProfileGeneralDto>, ProfileGeneralDtoValidator>();
        }
    }
}
