using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponseModel>> GetAllServices();
        Task<ServiceResponseModel> GetServiceById(int id);
        Task<bool> UpdateService(ServiceRequestModel serviceRequest);
        Task DeleteService(int id);
        Task<bool> CreateService(ServiceRequestModel serviceRequest);
    }
}
