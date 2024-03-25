using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Queries;
using Mc2.CrudTest.Api.Services;
using MediatR;

namespace Mc2.CrudTest.Api.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICrudService _service;

        public GetCustomersHandler(ICrudService service) => _service = service;

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request,
            CancellationToken cancellationToken) => await _service.GetAllAsync();
    }
}
