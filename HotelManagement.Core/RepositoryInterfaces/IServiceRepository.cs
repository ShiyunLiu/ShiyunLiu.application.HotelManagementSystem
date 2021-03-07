using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;

namespace HotelManagement.Core.RepositoryInterfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAllServices();
        Task<Service> GetServiceById(int id);
        Task<Service> AddService(Service service);
        Task<Service> UpdateService(Service service);
        Task<Service> DeleteService(Service service);
        Task<IEnumerable<Service>> ListServicesByFilter(Expression<Func<Service, bool>> filter);
    }
}
