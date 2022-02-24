using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class FaultApiController : Controller
    {
        private readonly MyContext _DbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public FaultApiController(MyContext DbContext, UserManager<ApplicationUser> userManager)
        {
            _DbContext = DbContext;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadoptions)
        {
            var data = _DbContext.FaultRecords;

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }

        //user bilgilerini getiren bir lookup kodu yazılacak
        public IActionResult GetUserLookup(DataSourceLoadOptions loadoptions)
        {
            //var data = await _userManager.FindByIdAsync(id);

            var data = _userManager.Users.Select(x => new
            {
                Key = x.Id,
                Value = $"{x.Name} {x.Surname}"
            });
            //var model = new
            //{
            //    Key = data.Id,
            //    Value = $"{data.Name} {data.Surname}"
            //};

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }
        public IActionResult GetTeknisyenLookup(DataSourceLoadOptions loadoptions)
        {
            //var data = await _userManager.FindByIdAsync(id);

            var data = _userManager.Users.Select(x => new
            {
                Key = x.Id,
                Value = $"{x.Name} {x.Surname}"
            });
            //var model = new
            //{
            //    Key = data.Id,
            //    Value = $"{data.Name} {data.Surname}"
            //};

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }
        public IActionResult GetOperatorLookup(DataSourceLoadOptions loadoptions)
        {
            //var data = await _userManager.FindByIdAsync(id);

            var data = _userManager.Users.Select(x => new
            {
                Key = x.Id,
                Value = $"{x.Name} {x.Surname}"
            });
            //var model = new
            //{
            //    Key = data.Id,
            //    Value = $"{data.Name} {data.Surname}"
            //};

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }

        //[HttpPut]
        //public IActionResult Update(int key, string values)
        //{
        //    var data = _DbContext.FaultRecords;
        //    if (data == null)
        //        return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = "Kullanıcı Bulunamadı"
        //        });

        //    JsonConvert.PopulateObject(values, data);
        //    if (!TryValidateModel(data))
        //        return BadRequest(ModelState.ToFullErrorString());

        //    var result = _DbContext.Update(data);
        //    return Ok(new JsonResponseViewModel());
        //}
    }
}
