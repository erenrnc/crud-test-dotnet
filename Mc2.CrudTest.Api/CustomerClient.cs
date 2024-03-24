using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Services;

namespace Mc2.CrudTest.Api
{
    public partial class CustomerSender
    {
        private readonly ICrudService _service;


        public CustomerSender(ICrudService service)
        {
            _service = service;
        }

        public async Task<CustomerResponse> Insert(Customer customer)
        {
            var result = await _service.InsertAsync(customer);
            return new CustomerResponse { Id = result, Info = "Success" };
        }

        public async Task<CustomerResponse> Update(Customer customer)
        {
            var result = await _service.UpdateAsync(customer);
            return new CustomerResponse { Result = result};
        }

        //public async Task<CustomerResponse> Delete(Customer customer)
        //{
        //    var result = await _service.DeleteAsync(customer);
        //    return new CustomerResponse { Result = result };
        //}

        public async Task<CustomerResponse> GetByEmail(string email)
        {
            var result = await _service.GetByEmailAsync(email);
            return new CustomerResponse { Result = result };
        }

        public async Task<CustomerResponse> GetAll()
        {
            var result = await _service.GetAllAsync();
            return new CustomerResponse { Result = result };
        }
    }
}
