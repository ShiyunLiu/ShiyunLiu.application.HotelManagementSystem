using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeResponseModel>> GetAllRoomTypes();
        Task<RoomTypeResponseModel> GetRoomTypeById(int id);
        Task<bool> UpdateRoomType(RoomTypeRequestModel roomTypeRequest);
        Task DeleteRoomType(int id);
        Task<bool> CreateRoomType(RoomTypeRequestModel roomTypeRequest);
    }
}
