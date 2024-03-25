using Mc2.CrudTest.Api.Models;
using MediatR;

namespace Mc2.CrudTest.Api.Queries
{
    public record GetCustomersQuery() : IRequest<IEnumerable<Customer>>;
}
