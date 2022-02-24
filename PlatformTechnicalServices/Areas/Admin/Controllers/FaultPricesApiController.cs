using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlatformTechnicalServices.Data;
using PlatformTechnicalServices.Extensions;
using PlatformTechnicalServices.Models.Entities;
using PlatformTechnicalServices.ViewModels;
using System.Linq;

namespace PlatformTechnicalServices.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class FaultPricesApiController : Controller
    {
        private readonly MyContext _DbContext;

        public FaultPricesApiController(MyContext dbContext)
        {
            _DbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadoptions)
        {
            var data = _DbContext.FaultPrices;

            return Ok(DataSourceLoader.Load(data, loadoptions));
        }

        [HttpPut]
        public IActionResult Update(int key, string values)
        {
            var data = _DbContext.FaultPrices.FirstOrDefault(x => x.FaultId == key);
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
        [HttpPost]
        public IActionResult Insert(string values)
        {
            var newFaultPrices = new FaultPrices();
            JsonConvert.PopulateObject(values, newFaultPrices);
            if (!TryValidateModel(newFaultPrices))
                return BadRequest(ModelState.ToFullErrorString());

            _DbContext.FaultPrices.Add(newFaultPrices);
            _DbContext.SaveChanges();

            return Ok(new JsonResponseViewModel());
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var data = _DbContext.FaultPrices.FirstOrDefault(x => x.FaultId == key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kayıt Bulunamadı"
                });

            _DbContext.FaultPrices.Remove(data);
            _DbContext.SaveChanges();

            return Ok(new JsonResponseViewModel());
        }
    }
}
