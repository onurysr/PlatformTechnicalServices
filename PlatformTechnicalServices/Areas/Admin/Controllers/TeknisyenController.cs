using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Models.Identity;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Teknisyen")]
    public class TeknisyenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MyContext _DbContext;

        public TeknisyenController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MyContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _DbContext = dbContext;
        }

        public IActionResult TeknisyenArizaKayitlarim()
        {
            return View();
        }
    }
}
