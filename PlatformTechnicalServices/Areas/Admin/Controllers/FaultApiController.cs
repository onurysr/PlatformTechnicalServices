using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Identity;
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
        public async Task<IActionResult> GetUserLookup(string id)
        {
            var data = await _userManager.FindByIdAsync(id);
            var model = new
            {
                Key = data.Id,
                Value = $"{data.Name} {data.Surname}"
            };

            return Ok(model);
        }
    }
}
