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
    public class ServiceRepository : IServiceRepository
    {
        private readonly HotelManagementDbContext _dbContext;
        public ServiceRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<Service> AddService(Service service)
        {
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<Service> DeleteService(Service service)
        {
            _dbContext.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<Service> GetServiceById(int id)
        {
            var service = await _dbContext.Services.FindAsync(id);
            return service;
        }

        public async Task<IEnumerable<Service>> ListAllServices()
        {
            return await _dbContext.Services.Include(s => s.Room).ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListServicesByFilter(Expression<Func<Service, bool>> filter)
        {
            return await _dbContext.Services.Where(filter).ToListAsync();
        }

        public async Task<Service> UpdateService(Service service)
        {
            _dbContext.Entry(service).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return service;
        }
    }
}
