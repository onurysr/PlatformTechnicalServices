using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> Update(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserDetailViewModel()
            {
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
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

        [HttpPost]
        public async Task<IActionResult> Update(UserDetailViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            //Kullanıcı update işlemleri
            user.Name = model.Name;
            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }    
            //Kullanıcı Rol işlemleri
            
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                var roleRemove = await _userManager.RemoveFromRoleAsync(user, role);
            }

            var selectedRole = await _roleManager.FindByIdAsync(model.SelectedRoleId);
            var roleAdd = await _userManager.AddToRoleAsync(user, selectedRole.Name);

            if (!roleAdd.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            TempData["mesaj"] = "Güncelleme işlemi başarılı";

            return LocalRedirect($"~/admin/manage/update/{user.Id}");
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            TempData["mesaj"] = "Silme işlemi başarılı";

            return LocalRedirect($"~/admin/manage/users");
        }

        public IActionResult Faults()
        {
            return View();
        }

        public IActionResult FaultPrices()
        {
            return View();
        }


    }
}
