using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
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

        public FaultApiController(MyContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadoptions)
        {
            var data = _DbContext.FaultRecords;

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }
    }
}
