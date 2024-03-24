using Mc2.CrudTest.Api.Models;

namespace Mc2.CrudTest.Api.Services
{
	public interface ICrudService
	{
        Task<int> InsertAsync(Customer smsOtp);
        Task<bool> UpdateAsync(Customer smsOtp);
        Task<bool> DeleteAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByEmailAsync(string email);
    }
}

