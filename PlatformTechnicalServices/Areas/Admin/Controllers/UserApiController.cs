using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Models.Identity;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [Authorize(Roles ="Admin")]
    public class UserApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
