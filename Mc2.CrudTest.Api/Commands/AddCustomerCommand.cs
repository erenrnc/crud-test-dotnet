using Mc2.CrudTest.Api.Models;
using MediatR;

namespace Mc2.CrudTest.Api.Commands
{
    public record AddCustomerCommand(Customer Customer) : IRequest<Customer>;
}
