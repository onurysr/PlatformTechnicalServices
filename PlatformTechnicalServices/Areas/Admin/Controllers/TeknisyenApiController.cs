using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using System.Linq;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Teknisyen")]
    public class TeknisyenApiController : Controller
    {
        private readonly MyContext _DbContext;

        public TeknisyenApiController(MyContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IActionResult Get(DataSourceLoadOptions loadoptions)
        {
            var model = _DbContext.FaultRecords.Include(x => x.User).Include(x => x.Operator).Where(x => x.TeknisyenId == HttpContext.GetUserId());

            return Ok(DataSourceLoader.Load(model, loadoptions));
        }
    }
}
