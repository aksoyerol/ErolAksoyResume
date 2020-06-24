using ErolAksoyResume.Business.Concrete;
using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErolAksoyResume.MVC.UI
{
    public static class IdentityInitilazier
    {
     

        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            var adminUser = await userManager.FindByNameAsync("pcparticle");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            if (adminUser == null)
            {
                AppUser appUser = new AppUser
                {
                    Name = "Erol",
                    LastName = "Aksoy",
                    UserName="pcparticle",
                    About = "Doldurulacak",
                    Adress = "Gelecek",
                    Email = "erolaksoy98@gmail.com",
                    Instagram = "eaksoy13"
                };

                await userManager.CreateAsync(appUser, "Onlineofline98.");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
        }


    }
}
