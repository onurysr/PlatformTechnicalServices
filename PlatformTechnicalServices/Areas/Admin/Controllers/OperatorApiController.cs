using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models;
using PlatformTechnicalServices.Models.Identity;
using PlatformTechnicalServices.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin,Operator")]
    [Route("api/[controller]/[action]")]
    public class OperatorApiController : Controller
    {
        private readonly MyContext _DbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OperatorApiController(MyContext DbContext, UserManager<ApplicationUser> userManager)
        {
            _DbContext = DbContext;
            _userManager = userManager;    
        }

        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _DbContext.FaultRecords.Include(x=>x.User).Include(x=>x.Teknisyen).Where(x=>x.OperatorId== HttpContext.GetUserId()).ToList();

            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult GetTeknisyenLookup(DataSourceLoadOptions loadoptions)
        {
            var data = _DbContext.Users.ToList();
            var model = new List<ApplicationUser>();

            foreach (var user in data)
            {
                if (_userManager.IsInRoleAsync(user, RoleModels.Teknisyen).Result)
                {
                    model.Add(user);
                }
            }
            return Ok(DataSourceLoader.Load(model, loadoptions));
        }

        public IActionResult Update(int key, string values)
        {
            var data = _DbContext.FaultRecords.FirstOrDefault(x => x.FaultId == key);
            if (data ==null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kayıt Bulunamadı"
                });
            }

            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            _DbContext.Update(data);
            _DbContext.SaveChanges();
          

            return Ok(new JsonResponseViewModel());


        }

    }
}
