using BusinessWithSupplier.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdqController : ControllerBase
    {
        private ICdqService cdqService;

        public CdqController(ICdqService cdqService)
        {
            this.cdqService = cdqService;
        }

        [HttpGet("getcities")]
        public IActionResult GetCities()
        {
            return Ok(cdqService.GetCities());
        }

        [HttpGet("getdistricts")]
        public IActionResult GetDistricts(int cityId)
        {
            return Ok(cdqService?.GetDistricts(cityId));
        }

        [HttpGet("getquarters")]
        public IActionResult GetQuarters(int districtId)
        {
            return Ok(cdqService?.GetQuarters(districtId));
        }
        [HttpGet("getquartername")]
        public IActionResult GetQuarterName(int quarterId)
        {
            return Ok(cdqService?.GetQuarterName(quarterId));
        }
        [HttpGet("getdistrictname")]
        public IActionResult GetDistrictName(int disrtrictId)
        {
            return Ok(cdqService?.GetDistrictName(disrtrictId));
        }
        [HttpGet("getcityname")]
        public IActionResult GetCityName(int cityId)
        {
            return Ok(cdqService?.GetCityName(cityId));
        }
    }
}
