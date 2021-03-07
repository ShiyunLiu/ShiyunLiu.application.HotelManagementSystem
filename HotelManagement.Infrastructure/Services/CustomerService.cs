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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateCustomer(CustomerRequestModel customerRequest)
        {
            var dbCustomer = await _customerRepository.GetCustomerById(customerRequest.Id);
            if (dbCustomer != null && string.Equals(dbCustomer.Id.ToString(),
                customerRequest.Id.ToString(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Customer already exists");
            var customer = new Customer()
            {
                Id = customerRequest.Id,
                RoomId = customerRequest.RoomId,
                CName = customerRequest.CName,
                Address = customerRequest.Address,
                Phone = customerRequest.Phone,
                Email = customerRequest.Email,
                CheckIn = customerRequest.CheckIn,
                TotalPersons = customerRequest.TotalPersons,
                BookingDays = customerRequest.BookingDays,
                Advance = customerRequest.Advance
            };
            var createCustomer = await _customerRepository.AddCustomer(customer);
            var response = new CustomerResponseModel()
            {
                Id = createCustomer.Id,
                RoomId = createCustomer.RoomId,
                CName = createCustomer.CName,
                Address = createCustomer.Address,
                Phone = createCustomer.Phone,
                Email = createCustomer.Email,
                CheckIn = createCustomer.CheckIn,
                TotalPersons = createCustomer.TotalPersons,
                BookingDays = createCustomer.BookingDays,
                Advance = createCustomer.Advance
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _customerRepository.ListCustomersByFilter(c => c.Id == id);
            await _customerRepository.DeleteCustomer(customer.First());
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
        {
            var customers = await _customerRepository.ListAllCustomers();
            var response = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                response.Add(new CustomerResponseModel
                {
                    Id = customer.Id,
                    RoomId = customer.RoomId,
                    CName = customer.CName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    CheckIn = customer.CheckIn,
                    TotalPersons = customer.TotalPersons,
                    BookingDays = customer.BookingDays,
                    Advance = customer.Advance

                });
            }
            return response;
        }

        public async Task<CustomerResponseModel> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            var response = new CustomerResponseModel
            {
                Id = customer.Id,
                RoomId = customer.RoomId,
                CName = customer.CName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                CheckIn = customer.CheckIn,
                TotalPersons = customer.TotalPersons,
                BookingDays = customer.BookingDays,
                Advance = customer.Advance
            };
            return response;
        }


        public async Task<bool> UpdateCustomer(CustomerRequestModel customerRequest)
        {
            var dbCustomer = await _customerRepository.GetCustomerById(customerRequest.Id);
            if (dbCustomer == null)
                throw new Exception("Customer does not exist");
            var customer = new Customer()
            {
                Id = customerRequest.Id,
                RoomId = customerRequest.RoomId,
                CName = customerRequest.CName,
                Address = customerRequest.Address,
                Phone = customerRequest.Phone,
                Email = customerRequest.Email,
                CheckIn = customerRequest.CheckIn,
                TotalPersons = customerRequest.TotalPersons,
                BookingDays = customerRequest.BookingDays,
                Advance = customerRequest.Advance
            };
            var updateCustomer = await _customerRepository.UpdateCustomer(customer);
            var response = new CustomerResponseModel()
            {
                Id = updateCustomer.Id,
                RoomId = updateCustomer.RoomId,
                CName = updateCustomer.CName,
                Address = updateCustomer.Address,
                Phone = updateCustomer.Phone,
                Email = updateCustomer.Email,
                CheckIn = updateCustomer.CheckIn,
                TotalPersons = updateCustomer.TotalPersons,
                BookingDays = updateCustomer.BookingDays,
                Advance = updateCustomer.Advance
            };
            if (response != null && response.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
