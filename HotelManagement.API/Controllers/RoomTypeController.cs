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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        [Route("{roomTypeId:int}")]
        public async Task<IActionResult> GetRoomTypeById(int roomTypeId)
        {
            var roomType = await _roomTypeService.GetRoomTypeById(roomTypeId);
            if (roomType != null)
            {
                return Ok(roomType);
            }

            return NotFound("No room type found");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypes();
            if (roomTypes != null)
            {
                return Ok(roomTypes);
            }

            return NotFound("No room types found");
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRoomType(RoomTypeRequestModel roomTypeRequest)
        {
            await _roomTypeService.CreateRoomType(roomTypeRequest);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRoomType(RoomTypeRequestModel roomTypeRequest)
        {
            await _roomTypeService.UpdateRoomType(roomTypeRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoomType(int roomTypeId)
        {
            await _roomTypeService.DeleteRoomType(roomTypeId);
            return NoContent();
        }
    }
}
