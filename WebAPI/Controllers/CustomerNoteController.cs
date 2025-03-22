using BusinessWithSupplier.Abstract;
using CleaningEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Supplier")]
    public class CustomerNoteController : ControllerBase
    {
        private ICustomerNoteService _customerNoteService;

        public CustomerNoteController(ICustomerNoteService customerNoteService)
        {
            _customerNoteService = customerNoteService;
        }

        [HttpGet("getbycustid")]
        public IActionResult Get(int custId)
        {
            var result = _customerNoteService.GetByCustomerId(custId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerNote customerNote) 
        {
            var result = _customerNoteService.Add(customerNote);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(CustomerNote customerNote)
        {
            var result = _customerNoteService.Update(customerNote);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CustomerNote customerNote)
        {
            var result = _customerNoteService.Delete(customerNote);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
