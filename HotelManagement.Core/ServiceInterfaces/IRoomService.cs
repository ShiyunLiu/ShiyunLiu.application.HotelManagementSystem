using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomResponseModel>> GetAllRooms();
        Task<RoomResponseModel> GetRoomById(int id);
        Task<bool> UpdateRoom(RoomRequestModel roomRequest);
        Task DeleteRoom(int id);
        Task<bool> CreateRoom(RoomRequestModel roomRequest);
    }
}
