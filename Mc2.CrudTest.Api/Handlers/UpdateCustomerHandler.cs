using Mc2.CrudTest.Api.Commands;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Services;
using MediatR;

namespace Mc2.CrudTest.Api.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICrudService _service;

        public UpdateCustomerHandler(ICrudService service) => _service = service;

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Customer);
            return request.Customer;
        }
    }
}
