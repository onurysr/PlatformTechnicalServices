using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Identity;
using System;
using System.Linq;

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
        public IActionResult TeknisyenTamamlananArizalar()
        {
            var values = _DbContext.FaultRecords.Include(x=>x.User).Where(x => x.AtanmaDurumu == true).ToList();


            return View(values);
        }
        public IActionResult CreateFatura(int id)
        {
            var values = _DbContext.FaultRecords.Include(x => x.User).Where(x => x.FaultId == id).FirstOrDefault();
            var faultPriceObj = _DbContext.FaultPrices.ToList();
            TempData["faultPriceObj"] = faultPriceObj;
            return View(values);
        }
    }
}
