using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlatformTechnicalServices.Models.Identity;
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
            var a = _userManager.Users;
            return View(a);
        }
        public async Task<IActionResult> Details(string? id)
        {
            var a = await _userManager.FindByIdAsync(id);
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
