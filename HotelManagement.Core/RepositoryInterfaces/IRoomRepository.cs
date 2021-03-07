using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;

namespace HotelManagement.Core.RepositoryInterfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAllRooms();
        Task<Room> GetRoomById(int id);
        Task<Room> AddRoom(Room room);
        Task<Room> UpdateRoom(Room room);
        Task<Room> DeleteRoom(Room room);
        Task<IEnumerable<Room>> ListRoomsByFilter(Expression<Func<Room, bool>> filter);
    }
}
