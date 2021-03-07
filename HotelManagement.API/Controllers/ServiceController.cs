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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service != null)
            {
                return Ok(service);
            }

            return NotFound("Not service found");
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceService.GetAllServices();
            if (services != null)
            {
                return Ok(services);
            }

            return NotFound("No services found");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateService([FromBody]ServiceRequestModel serviceRequest)
        {
            await _serviceService.CreateService(serviceRequest);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateService([FromBody]ServiceRequestModel serviceRequest)
        {
            await _serviceService.UpdateService(serviceRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteService(id);
            return NoContent();
        }
    }
}
