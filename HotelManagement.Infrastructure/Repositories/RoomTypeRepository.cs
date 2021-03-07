using System;
using System.Collections.Generic;
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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelManagementDbContext _dbContext;

        public RoomTypeRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<RoomType> AddRoomType(RoomType roomType)
        {
            await _dbContext.RoomTypes.AddAsync(roomType);
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task<RoomType> DeleteRoomType(RoomType roomType)
        {
            _dbContext.Remove(roomType);
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task<RoomType> GetRoomTypeById(int id)
        {
            var roomType = await _dbContext.RoomTypes.FindAsync(id);
            return roomType;
        }

        public async Task<IEnumerable<RoomType>> ListAllRoomTypes()
        {
            return await _dbContext.RoomTypes.ToListAsync();
        }

        public async Task<IEnumerable<RoomType>> ListRoomTypesByFilter(Expression<Func<RoomType, bool>> filter)
        {
            return await _dbContext.RoomTypes.Where(filter).ToListAsync();
        }

        public async Task<RoomType> UpdateRoomType(RoomType roomType)
        {
            _dbContext.Entry(roomType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return roomType; 
        }
    }
}
