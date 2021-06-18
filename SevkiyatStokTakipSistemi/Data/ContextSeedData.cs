using Microsoft.AspNetCore.Identity;
using SevkiyatStokTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Data
{
    public class ContextSeedData
    {


        public static async Task SeedRolesAsync(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.yönetici.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.siparis.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.sevkiyat.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.güvenlik.ToString()));
        }

        public static async Task SeedYoneticiAsync(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new AppUser
            {
                UserName = "superadmin",
                Email = "superadmin@superadmin.com",
                FirstName = "Testsuperadmin",
                LastName = "Testsuperadmin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };

            if (userManager.Users.All(u=>u.Id != defaultUser.Id))
            {
                var user =await userManager.FindByEmailAsync(defaultUser.Email);

                if (user==null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.güvenlik.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.sevkiyat.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.siparis.ToString());

                }
            }
        }
    }
}
