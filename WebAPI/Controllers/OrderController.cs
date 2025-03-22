using BusinessWithSupplier.Abstract;
using CleaningEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Supplier, Terminal")]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Add(Order order)
        {
            var result = orderService.Add(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult Update(Order order)
        {
            var result = orderService.Update(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Admin,Supplier")]
        public IActionResult GetAll(int supplierId)
        {
            //var result = orderService.GetList(suplierId);
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            var result = orderService.GetList(DateTime.Now.AddDays(-60).Date, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbydate1")]
        public IActionResult GetByDate(DateTime date,int supplierId)
        {
            var result = orderService.GetList(date, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbydate2")]
        public IActionResult GetByDate(DateTime dateFirst, DateTime dateLast, int supplierId)
        {
            var result = orderService.GetList(dateFirst,dateLast, supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = orderService.GetListByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyorderid")]
        public IActionResult GetByOrderId(int orderId)
        {
            var result = orderService.GetByOrderId(orderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
