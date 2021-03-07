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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<bool> CreateRoomType(RoomTypeRequestModel roomTypeRequest)
        {
            var dbRoomType = await _roomTypeRepository.GetRoomTypeById(roomTypeRequest.Id);
            if (dbRoomType != null && string.Equals(dbRoomType.Id.ToString(),
                roomTypeRequest.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Room type already exists");
            var roomType = new RoomType()
            {
                Id = roomTypeRequest.Id,
                RtDesc = roomTypeRequest.RtDesc,
                Rent = roomTypeRequest.Rent
            };
            var createRoomType = await _roomTypeRepository.AddRoomType(roomType);
            var response = new RoomTypeResponseModel()
            {
                Id = createRoomType.Id,
                RtDesc = createRoomType.RtDesc,
                Rent = createRoomType.Rent
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteRoomType(int id)
        {
            var roomType = await _roomTypeRepository.ListRoomTypesByFilter(t => t.Id == id);
            await _roomTypeRepository.DeleteRoomType(roomType.First());
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> GetAllRoomTypes()
        {
            var roomTypes = await _roomTypeRepository.ListAllRoomTypes();
            var response = new List<RoomTypeResponseModel>();
            foreach (var roomType in roomTypes)
            {
                response.Add(new RoomTypeResponseModel
                {
                    Id = roomType.Id,
                    RtDesc = roomType.RtDesc,
                    Rent = roomType.Rent
                });
            }

            return response;
        }

        public async Task<RoomTypeResponseModel> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeById(id);
            var response = new RoomTypeResponseModel
            {
                Id = roomType.Id,
                RtDesc = roomType.RtDesc,
                Rent = roomType.Rent
            };
            return response;
        }

        public async Task<bool> UpdateRoomType(RoomTypeRequestModel roomTypeRequest)
        {
            var dbRoomType = await _roomTypeRepository.GetRoomTypeById(roomTypeRequest.Id);
            if (dbRoomType == null)
                throw new Exception("Room type does not exist");
            var roomType = new RoomType()
            {
                Id = roomTypeRequest.Id,
                RtDesc = roomTypeRequest.RtDesc,
                Rent = roomTypeRequest.Rent
            };
            var updateRoomType = await _roomTypeRepository.UpdateRoomType(roomType);
            var response = new RoomTypeResponseModel()
            {
                Id = updateRoomType.Id,
                RtDesc = updateRoomType.RtDesc,
                Rent = updateRoomType.Rent
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
