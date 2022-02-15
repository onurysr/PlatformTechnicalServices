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
            var roles = _roleManager.Roles;
            var user =await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var c = _userManager.GetRolesAsync(user);
            var roleList = new List<UserDetailRolesViewModel>();
            foreach (var item in roles)
            {
                roleList.Add(new UserDetailRolesViewModel
                {
                    RoleId = item.Id,
                    RoleName = item.Name
                });
            }


            var a = await _userManager.FindByIdAsync(id);

            var model = new UserDetailViewModel()
            {
                Name = a.Name,
                UserName = a.UserName,
                CreatedDate = a.CreatedDate,
                Email = a.Email,
                IsActive = a.EmailConfirmed,
                Roles = roleList
            };
            ViewBag.Roles = GetRoleList();
            return View(a);
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
