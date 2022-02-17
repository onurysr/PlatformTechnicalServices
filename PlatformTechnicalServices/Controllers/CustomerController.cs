using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddFault()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null) return BadRequest(string.Empty);
            ViewBag.UserName=user.UserName;
            ViewBag.Email=user.Email;
            return View();
        }

        [HttpPost]
        public IActionResult AddFault(AddFaultViewModel addFaultViewModel)
        {
            return View();
        }
    }
}
