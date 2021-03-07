using HotelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Customer customer);
        Task<IEnumerable<Customer>> ListCustomersByFilter(Expression<Func<Customer, bool>> filter);
    }
}
