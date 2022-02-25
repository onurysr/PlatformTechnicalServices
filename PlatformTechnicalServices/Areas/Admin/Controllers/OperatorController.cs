using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Operator")]
    public class OperatorController : Controller
    {
        public IActionResult MyFaults()
        {
            return View();
        }
    }
}
