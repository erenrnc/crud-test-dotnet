using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Queries;
using Mc2.CrudTest.Api.Services;
using MediatR;

namespace Mc2.CrudTest.Api.Handlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly ICrudService _service;

        public GetCustomerByEmailHandler(ICrudService service) => _service = service;

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken) =>
            await _service.GetByEmailAsync(request.email);

    }
}
