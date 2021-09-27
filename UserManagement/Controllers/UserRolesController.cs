using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userRolesViewModels = new List<UserRolesViewModel>();

            foreach (ApplicationUser user in users)
            {
                var viewModel = new UserRolesViewModel();
                viewModel.FirstName = user.FirstName;
                viewModel.LastName = user.LastName;
                viewModel.Email = user.Email;
                viewModel.UserId = user.Id;
                viewModel.Roles = await GetUserRoles(user);
                userRolesViewModels.Add(viewModel);
            }

            return View(userRolesViewModels);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
