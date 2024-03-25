using Mc2.CrudTest.Api.Models;
using MediatR;

namespace Mc2.CrudTest.Api.Commands
{
    public record UpdateCustomerCommand(Customer Customer) : IRequest<Customer>;
}
