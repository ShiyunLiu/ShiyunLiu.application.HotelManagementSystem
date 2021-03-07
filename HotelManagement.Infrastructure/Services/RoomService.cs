using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Core.ServiceInterfaces;

namespace HotelManagement.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<bool> CreateRoom(RoomRequestModel roomRequest)
        {
            var dbRoom = await _roomRepository.GetRoomById(roomRequest.Id);
            if (dbRoom != null && string.Equals(dbRoom.Id.ToString(),
                roomRequest.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Room already exists");
            var room = new Room()
            {
                Id = roomRequest.Id,
                RoomTypeId = roomRequest.RoomTypeId,
                Status = roomRequest.Status
            };
            var createRoom = await _roomRepository.AddRoom(room);
            var response = new RoomResponseModel()
            {
                Id = createRoom.Id,
                RoomTypeId = createRoom.RoomTypeId,
                Status = createRoom.Status
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _roomRepository.ListRoomsByFilter(r => r.Id == id);
            await _roomRepository.DeleteRoom(room.First());
        }

        public async Task<IEnumerable<RoomResponseModel>> GetAllRooms()
        {
            var rooms = await _roomRepository.ListAllRooms();
            var response = new List<RoomResponseModel>();
            foreach (var room in rooms)
            {
                response.Add(new RoomResponseModel
                {
                    Id = room.Id,
                    RoomTypeId = room.RoomTypeId,
                    Status = room.Status
                });
            }

            return response;
        }

        public async Task<RoomResponseModel> GetRoomById(int id)
        {
            var room = await _roomRepository.GetRoomById(id);
            var response = new RoomResponseModel
            {
                Id = room.Id,
                RoomTypeId = room.RoomTypeId,
                Status = room.Status
            };
            return response;
        }

        public async Task<bool> UpdateRoom(RoomRequestModel roomRequest)
        {
            var dbRoom = await _roomRepository.GetRoomById(roomRequest.Id);
            if (dbRoom == null)
                throw new Exception("Room does not exist");
            var room = new Room()
            {
                Id = roomRequest.Id,
                RoomTypeId = roomRequest.RoomTypeId,
                Status = roomRequest.Status
            };
            var updateRoom = await _roomRepository.UpdateRoom(room);
            var response = new RoomResponseModel()
            {
                Id = updateRoom.Id,
                RoomTypeId = updateRoom.RoomTypeId,
                Status = updateRoom.Status
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
