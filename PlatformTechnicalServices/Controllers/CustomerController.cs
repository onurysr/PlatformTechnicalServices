using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Entities;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly MyContext _DbContext;

        public CustomerController(UserManager<ApplicationUser> userManager,MyContext Dbcontext)
        {
            _userManager = userManager;
            _DbContext = Dbcontext;
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
            var model = new FaultRecord
            {
                PhoneNumber = addFaultViewModel.PhoneNumber
            };

            _DbContext.FaultRecords.Add(model);
            _DbContext.SaveChanges();
            

            return View();
        }
    }
}
