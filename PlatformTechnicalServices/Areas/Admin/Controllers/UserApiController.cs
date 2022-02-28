﻿using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class UserApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserApiController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;

            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPut]
        public async Task<IActionResult> Update(string key, string values)
        {
            var data = _userManager.Users.FirstOrDefault(x => x.Id == key);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Bulunamadı"
                });
            }

            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
            {
                return BadRequest(ModelState.ToFullErrorString());
            }

            var result = await _userManager.UpdateAsync(data);
            return Ok(new JsonResponseViewModel());
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string key)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == key);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Bulunamadı"
                });
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Silinemedi."
                });
            }
            return Ok(new JsonResponseViewModel());
        }

        //public IActionResult GetRolesLookUp(string key, DataSourceLoadOptions loadOptions)
        //{
        //    var users = _userManager.Users.Where(x=>x.Id ==key).ToList();
        //    //var role = _userManager.GetRolesAsync(user);
        //    //var roles = _roleManager.Roles.ToList();
        //    //var model = new List<ApplicationRole>();
        //    //foreach (var role in roles)
        //    //{
        //    //    model.Add(role);
        //    //}
        //    return Ok(DataSourceLoader.Load(model, loadOptions));
        //}
    }
}
