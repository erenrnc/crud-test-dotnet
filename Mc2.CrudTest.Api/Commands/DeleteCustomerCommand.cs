using MediatR;

namespace Mc2.CrudTest.Api.Commands
{
    public record DeleteCustomerCommand(int Id) : IRequest;
}
