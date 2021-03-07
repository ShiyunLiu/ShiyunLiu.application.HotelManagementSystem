using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.ServiceInterfaces;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound("No customer found");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            if (customers != null)
            {
                return Ok(customers);
            }

            return NotFound("No customers found");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCustomer([FromBody]CustomerRequestModel customerRequest)
        {
            await _customerService.CreateCustomer(customerRequest);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody]CustomerRequestModel customerRequest)
        {
            await _customerService.UpdateCustomer(customerRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
