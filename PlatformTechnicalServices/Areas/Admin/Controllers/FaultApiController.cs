using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Entities;
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
                UserId= x.Id,
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
                TeknisyenId = x.Id,
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
                OperatorId = x.Id,
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

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var data = _DbContext.FaultRecords.FirstOrDefault(x => x.FaultId == key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kayıt Bulunamadı"
                });

            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            _DbContext.Update(data);
            _DbContext.SaveChanges();

            return Ok(new JsonResponseViewModel());
        }
        //[HttpPost]
        //public IActionResult Insert(string values)
        //{
        //    var newFaultRecord = new FaultRecord();
        //    JsonConvert.PopulateObject(values, newFaultRecord);
        //    if (!TryValidateModel(newFaultRecord))
        //        return BadRequest(ModelState.ToFullErrorString());

        //    _DbContext.FaultRecords.Add(newFaultRecord);
        //    _DbContext.SaveChanges();

        //    return Ok(new JsonResponseViewModel());
        //}
        //[HttpDelete]
        //public IActionResult Delete(int key)
        //{
        //    var data = _DbContext.FaultRecords.FirstOrDefault(x=>x.FaultId == key);
        //    if (data == null)
        //        return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
        //        {
        //            IsSuccess = false,
        //            ErrorMessage = "Kayıt Bulunamadı"
        //        });

        //    _DbContext.FaultRecords.Remove(data);
        //    _DbContext.SaveChanges();

        //    return Ok(new JsonResponseViewModel());
        //}
    }
}
