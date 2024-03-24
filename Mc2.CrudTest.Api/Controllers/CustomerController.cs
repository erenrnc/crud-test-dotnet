using AutoMapper;
using Mc2.CrudTest.Api.Commands;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Queries;
using Mc2.CrudTest.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        //private readonly ICrudService _service;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger,
            //ICrudService service,
            IMapper mapper,
            IMediator mediator)
        {
            _logger = logger;
            //_service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> insert(CustomerRequest request)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.Insert(_mapper.Map<Customer>(request));
            //return Ok(response);

            await _mediator.Send(new AddCustomerCommand(_mapper.Map<Customer>(request)));
            return StatusCode(201);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> update(CustomerRequest request)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.Update(_mapper.Map<Customer>(request));
            //return Ok(response);

            await _mediator.Send(new UpdateCustomerCommand(_mapper.Map<Customer>(request)));
            return StatusCode(201);
        }

        [HttpDelete("{id}", Name = "delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> delete(int id)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.Delete(_mapper.Map<Customer>(request));
            //return Ok(response);
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

        [HttpGet("{email}", Name = "getbyemail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> getbyemail(string email)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.GetByEmail(email);
            //return Ok(response);

            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));
            return Ok(customer);
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> getall()
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.GetAll();
            //return Ok(response);

            var customers = await _mediator.Send(new GetCustomersQuery());
            return Ok(customers);
        }
    }
}
