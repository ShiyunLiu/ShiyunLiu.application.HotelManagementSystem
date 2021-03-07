using HotelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.RepositoryInterfaces
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> ListAllRoomTypes();
        Task<RoomType> GetRoomTypeById(int id);
        Task<RoomType> AddRoomType(RoomType roomType);
        Task<RoomType> UpdateRoomType(RoomType roomType);
        Task<RoomType> DeleteRoomType(RoomType roomType);
        Task<IEnumerable<RoomType>> ListRoomTypesByFilter(Expression<Func<RoomType, bool>> filter);
    }
}