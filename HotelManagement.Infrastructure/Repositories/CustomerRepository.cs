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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelManagementDbContext _dbContext;
        public CustomerRepository(HotelManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            _dbContext.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            return await _dbContext.Customers.Include(c => c.Room).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> ListCustomersByFilter(Expression<Func<Customer, bool>> filter)
        {
            return await _dbContext.Customers.Where(filter).ToListAsync();
        }
    }
}
