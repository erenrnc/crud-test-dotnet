using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Api.Commands;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Queries;
using Mc2.CrudTest.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICrudService _service;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IValidator<Customer> _validator;

        public CustomerController(ILogger<CustomerController> logger,
            ICrudService service,
            IMapper mapper,
            IMediator mediator,
            IValidator<Customer> validator)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _mediator = mediator; 
            _validator = validator;
        }

        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> insert(CustomerRequest request)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.Insert(_mapper.Map<Customer>(request));
            //return Ok(response);
//            {
//                "firstName": "string4",
            //  "lastName": "string4",
            //  "dateOfBirth": "2000-03-25T11:43:20.283Z",
            //  "phoneNumber": "+902123456789",
            //  "email": "test4@test4.com",
            //  "bankAccountNumber": "123456"
            //}
            var map = _mapper.Map<Customer>(request);

            var validationResult = _validator.Validate(map);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            if (await _service.CheckCustomer(map))
            {
                return BadRequest("This customer is contain");
            }
            await _mediator.Send(new AddCustomerCommand(map));
            return StatusCode(201);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> update(CustomerUpdateRequest request)
        {
            //CustomerSender sender = new CustomerSender(_service);
            //var response = await sender.Update(_mapper.Map<Customer>(request));
            //return Ok(response);

            var map = _mapper.Map<Customer>(request);

            var validationResult = _validator.Validate(map);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (await _service.CheckCustomer(map))
            {
                return BadRequest("This customer is contain");
            }

            await _mediator.Send(new UpdateCustomerCommand(map));
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
