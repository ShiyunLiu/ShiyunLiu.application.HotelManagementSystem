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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room != null)
            {
                return Ok(room);
            }

            return NotFound("No room found");
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            if (rooms != null)
            {
                return Ok(rooms);
            }

            return NotFound("No rooms found");

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRoom([FromBody]RoomRequestModel roomRequest)
        {
            await _roomService.CreateRoom(roomRequest);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRoom([FromBody]RoomRequestModel roomRequest)
        {
            await _roomService.UpdateRoom(roomRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoom(id);
            return NoContent();
        }
    }
}
