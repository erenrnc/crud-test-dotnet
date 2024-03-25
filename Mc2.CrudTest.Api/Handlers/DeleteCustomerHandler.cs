using Mc2.CrudTest.Api.Commands;
using Mc2.CrudTest.Api.Services;
using MediatR;

namespace Mc2.CrudTest.Api.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICrudService _service;

        public DeleteCustomerHandler(ICrudService service) => _service = service;

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);
        }
    }
}
