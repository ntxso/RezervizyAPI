using BusinessWithSupplier.Abstract;
using CleaningEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Supplier, Terminal")]
    public class AddressController : ControllerBase
    {
        private IAddressService addressService;
        private ICdqService cdqService;

        public AddressController(IAddressService addressService,ICdqService cdqService)
        {
            this.addressService = addressService;
            this.cdqService = cdqService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult GetList()
        {
            var result = addressService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int id) 
        {
            var result = addressService.GetByCustomerId(id);
            if (result.Success) { return Ok(result.Data); }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Add(AddressCustomer address)
        {
            var result = addressService.Add(address);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Update(AddressCustomer address)
        {
            var result = addressService.Update(address);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcities")]
        public IActionResult GetCities()
        {
            return Ok(cdqService.GetCities());
        }

        [HttpGet("getdistricts")]
        public IActionResult GetDistricts(int cityId)
        {
            return Ok(cdqService.GetDistricts(cityId));
        }

        [HttpGet("getquarters")]
        public IActionResult GetQuarters(int distId)
        {
            return Ok(cdqService.GetQuarters(distId));
        }

        [HttpPost("getfulladdress")]
        public IActionResult GetFullAddress(AddressCustomer address)
        {
            return Ok(cdqService.GetFullAddress(address));
        }

        [HttpPost("getfulladdressdto")]
        public IActionResult GetFullAddressDto(CustomerDto address)
        {
            return Ok(cdqService.GetFullAddress(address));
        }
    }
}
