using BusinessWithSupplier.Abstract;
using CleaningEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Supplier, Terminal")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet("getall")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult GetList(int supplierId)
        {
            var result = customerService.GetList(supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetCustomerById(int id)
        {
            var result = customerService.GetCustomerById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlastcustomer")]
        public IActionResult GetLastCustomer(int supplierId)
        {
            var result = customerService.GetLastCustomer(supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyphone")]
        public IActionResult GetCustomersByPhone(string phone, int supplierId)
        {
            var result = customerService.GetListByPhoneNumber(phone,supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyname")]
        public IActionResult GetCustomersName(string name, int supplierId)
        {
            var result = customerService.GetListByName(name, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistdto")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult GetListDto(int supplierId)
        {
            var result = customerService.GetCustomersDto(supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyiddto")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetByIdDto(int id)
        {
            var result = customerService.GetCustomerDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyphonedto")]
        public IActionResult GetByPhoneDto(string phone, int supplierId)
        {
            var result = customerService.GetCustomersDtoByPhoneNumber(phone, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbynamedto")]
        public IActionResult GetNameDto(string name, int supplierId)
        {
            var result = customerService.GetCustomersDtoByName(name, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getbyidlistsdto")]
        public IActionResult GetCustomersByOrders(IEnumerable<int> custIds,int? supplierId)
        {
            if (supplierId == null)
            {
                supplierId = 0;
            }
            var result = customerService.GetCustomersDto(supplierId);
            if(result.Success)
            {
                var allList = (from cust in result.Data
                               join custId in custIds
                               on cust.CustomerId equals custId
                               select cust);
                return Ok(allList);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Add(Customer customer)
        {
            var result = customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Update(Customer customer)
        {
            var result = customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
