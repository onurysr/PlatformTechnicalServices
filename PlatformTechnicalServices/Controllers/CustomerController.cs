using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Entities;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly MyContext _DbContext;


        public CustomerController(UserManager<ApplicationUser> userManager, MyContext Dbcontext)
        {
            _userManager = userManager;
            _DbContext = Dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> AddFault()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null) return BadRequest(string.Empty);
            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
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
                UserId = user.Id,
                Subject = model.Subject
            };

            _DbContext.FaultRecords.Add(data);

            try
            {
                _DbContext.SaveChanges();
                TempData["message"] = "Arıza Kaydı Başarılı Bir Şekilde Eklendi";
                return RedirectToAction(nameof(MyFaults));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
                TempData["message"] = "Baaaaaaam";
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> MyFaults()
        {

            var Musteri = await _userManager.FindByIdAsync(HttpContext.GetUserId());

            var data = _DbContext.FaultRecords.Where(x => x.UserId == Musteri.Id).ToList();


            var model = new List<MyFaultsViewModel>();

            foreach (var item in data)
            {
                MyFaultsViewModel model1 = new MyFaultsViewModel
                {
                    CreatedDate = item.FaultCreateDate,
                    FaultId = item.FaultId,
                    Subject = item.Subject
                };
                model.Add(model1);
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> FaultDetails(int id)
        {

            var data = _DbContext.FaultRecords.FirstOrDefault(x=>x.FaultId == id);

            var user = await _userManager.FindByIdAsync(data.UserId);
            var teknisyen = await _userManager.FindByIdAsync(data.TeknisyenId);

            if (data == null)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
                return View();
            }

            var model = new FaultDetailViewModel
            {
                FaultId=data.FaultId,
                Address = data.Address,
                Description = data.Description,
                FullName = user.Name + " " + user.Surname,
                Subject = data.Subject,
                PhoneNumber = data.PhoneNumber,
                TechnicianName = teknisyen?.Name,
                CompletionDate = data.CompletionDate,
                AssignmentStatus = data.AtanmaDurumu,
                FaultCreatedDate = data.FaultCreateDate,
                TechnicianAssignmentDate = data.TechnicianAssignmentDate
            };


            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var arıza = _DbContext.FaultRecords.FirstOrDefault(x => x.FaultId == id);
            if (arıza == null)
            {
                return NotFound();
            }

            try
            {
                _DbContext.FaultRecords.Remove(arıza);
                _DbContext.SaveChanges();
                TempData["mesaj"] = "Silme işlemi Başarılı";

                return RedirectToAction(nameof(MyFaults));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
                return View();
            }
            
        }
    }
}
