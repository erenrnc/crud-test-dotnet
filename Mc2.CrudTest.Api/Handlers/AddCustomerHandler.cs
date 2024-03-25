using Mc2.CrudTest.Api.Commands;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Services;
using MediatR;

namespace Mc2.CrudTest.Api.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly ICrudService _service;

        public AddCustomerHandler(ICrudService service) => _service = service;

        public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            await _service.InsertAsync(request.Customer);
            return request.Customer;
        }
    }
}
