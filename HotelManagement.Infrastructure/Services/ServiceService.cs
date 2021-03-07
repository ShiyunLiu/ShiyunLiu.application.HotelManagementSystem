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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<bool> CreateService(ServiceRequestModel serviceRequest)
        {
            var dbService = await _serviceRepository.GetServiceById(serviceRequest.Id);
            if (dbService != null && string.Equals(dbService.Id.ToString(),
                serviceRequest.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Service already exists");
            var service = new Service()
            {
                Id = serviceRequest.Id,
                RoomId = serviceRequest.RoomId,
                SDesc = serviceRequest.SDesc,
                Amount = serviceRequest.Amount,
                ServiceDate = serviceRequest.ServiceDate
            };
            var createService = await _serviceRepository.AddService(service);
            var response = new ServiceResponseModel()
            {
                Id = createService.Id,
                RoomId = createService.RoomId,
                SDesc = createService.SDesc,
                Amount = createService.Amount,
                ServiceDate = createService.ServiceDate
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteService(int id)
        {
            var service = await _serviceRepository.ListServicesByFilter(s => s.Id == id);
            await _serviceRepository.DeleteService(service.First());
        }

        public async Task<IEnumerable<ServiceResponseModel>> GetAllServices()
        {
            var services = await _serviceRepository.ListAllServices();
            var response = new List<ServiceResponseModel>();
            foreach (var service in services)
            {
                response.Add(new ServiceResponseModel
                {
                    Id = service.Id,
                    RoomId = service.RoomId,
                    SDesc = service.SDesc,
                    Amount = service.Amount,
                    ServiceDate = service.ServiceDate
                });
            }

            return response;
        }

        public async Task<ServiceResponseModel> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetServiceById(id);
            var response = new ServiceResponseModel
            {
                Id = service.Id,
                RoomId = service.RoomId,
                SDesc = service.SDesc,
                Amount = service.Amount,
                ServiceDate = service.ServiceDate
            };
            return response;
        }

        public async Task<bool> UpdateService(ServiceRequestModel serviceRequest)
        {
            var dbService = await _serviceRepository.GetServiceById(serviceRequest.Id);
            if (dbService == null)
                throw new Exception("Service does not exist");
            var service = new Service()
            {
                Id = serviceRequest.Id,
                RoomId = serviceRequest.RoomId,
                SDesc = serviceRequest.SDesc,
                Amount = serviceRequest.Amount,
                ServiceDate = serviceRequest.ServiceDate
            };
            var updateService = await _serviceRepository.UpdateService(service);
            var response = new ServiceResponseModel()
            {
                Id = updateService.Id,
                RoomId = updateService.RoomId,
                SDesc = updateService.SDesc,
                Amount = updateService.Amount,
                ServiceDate = updateService.ServiceDate
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
