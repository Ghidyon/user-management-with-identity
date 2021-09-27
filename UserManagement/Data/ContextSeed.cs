using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagement.Models;

namespace UserManagement.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //See default user
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@domain.com",
                FirstName = "Gideon",
                LastName = "Akunana",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.SuperAdmin.ToString());
                }
            }
        }
    }
}
