using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErolAksoyResume.Business.Concrete;
using ErolAksoyResume.Business.Containers.MicrosoftIoc;
using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Context;
using ErolAksoyResume.Entities.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErolAksoyResume.MVC.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies();
            services.AddDbContext<MyContext>();
            services.AddIdentity<AppUser, AppRole>(opt=> {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric =false ;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                
            }).AddEntityFrameworkStores<MyContext>();
            services.AddAutoMapper(typeof(Startup));

            services.ConfigureApplicationCookie(opt => {
                opt.LoginPath = new PathString("/Home/Index");
                opt.AccessDeniedPath = new PathString("/Home/Error");
                opt.Cookie.Name = "ErolAksoyCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
            });

         
            services.AddControllersWithViews().AddFluentValidation();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            IdentityInitilazier.SeedData(userManager, roleManager).Wait();

            app.UseEndpoints(endpoints =>
            {
                

                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
