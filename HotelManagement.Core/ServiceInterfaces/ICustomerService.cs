using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseModel>> GetAllCustomers();
        Task<CustomerResponseModel> GetCustomerById(int id);
        Task<bool> UpdateCustomer(CustomerRequestModel customerRequest);
        Task DeleteCustomer(int id);
        Task<bool> CreateCustomer(CustomerRequestModel customerRequest);
    }
}
