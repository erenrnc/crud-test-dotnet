using Mc2.CrudTest.Api.Data;
using Mc2.CrudTest.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Api.Services
{
    public class CrudService : ICrudService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CrudService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> InsertAsync(Customer customer)
        {
            await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                _applicationDbContext.Customers.Update(customer);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var customer = await _applicationDbContext.Customers.FindAsync(id);
                if (customer != null)
                {
                    _applicationDbContext.Customers.Remove(customer);
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _applicationDbContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            var customer = await _applicationDbContext.Customers
                .OrderByDescending(i => i.Id)
                .Where(i => i.Email.Equals(email))
                .FirstOrDefaultAsync();
            return customer;
        }

        public async Task<bool> CheckCustomer(Customer customer)
        {
           return await _applicationDbContext.Customers.AnyAsync(c =>
            c.Email == customer.Email &&
            c.FirstName == customer.FirstName &&
            c.LastName == customer.LastName &&
            c.DateOfBirth == customer.DateOfBirth);
        }
    }
}

