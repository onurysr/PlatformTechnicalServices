using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Models;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ManageController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public async Task<IActionResult> Details(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserDetailViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                CreatedDate = user.CreatedDate,
                Email = user.Email,
                IsActive = user.EmailConfirmed,
                UserRoles = userRoles
            };

            var roleList = GetRoleList();
            foreach (var role in roleList)
            {
                if (userRoles.Contains(role.Text))
                {
                    role.Selected = true;
                }
            }

            ViewBag.Roles = roleList;
            return View(model);
        }

        private List<SelectListItem> GetRoleList()
        {
            var roles = _roleManager.Roles;
            var rolList = new List<SelectListItem>();

            foreach (var role in roles)
            {
                rolList.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }
            return rolList;
        }
    }
}
