using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Entities;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System;
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
        public async Task<IActionResult> AddFault(AddFaultViewModel model)
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var data = new FaultRecord
            {
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                AtanmaDurumu = false,
                Description = model.Description,
                FaultCreateDate = DateTime.Now,
                UserId=user.Id
            };

            _DbContext.FaultRecords.Add(data);

            try
            {
                _DbContext.SaveChanges();
                TempData["message"] = "Arıza kaydı başarılı bir şekilde oluşturuldu.";
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
               ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
                TempData["message"] = "Arıza kaydı Oluşturulamadı.";
                return View(model);
            }
        }
    }
}
