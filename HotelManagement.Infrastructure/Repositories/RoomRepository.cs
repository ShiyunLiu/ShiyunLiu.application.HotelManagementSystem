using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelManagementDbContext _dbContext;

        public RoomRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> AddRoom(Room room)
        {
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoom(Room room)
        {
            _dbContext.Remove(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            return room;
        }

        public async Task<IEnumerable<Room>> ListAllRooms()
        {
            return await _dbContext.Rooms.Include(r => r.RoomType).ToListAsync();
        }

        public async Task<IEnumerable<Room>> ListRoomsByFilter(Expression<Func<Room, bool>> filter)
        {
            return await _dbContext.Rooms.Where(filter).ToListAsync();
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            _dbContext.Entry(room).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return room;
        }
    }
}
