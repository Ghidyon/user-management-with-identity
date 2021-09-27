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
    }
}
