using AutoMapper;
using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICrudService _service;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger,
            ICrudService service,
            IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> insert(CustomerRequest request)
        {
            CustomerSender sender = new CustomerSender(_service);
            var response = await sender.Insert(_mapper.Map<Customer>(request));
            return Ok(response);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> update(CustomerRequest request)
        {
            CustomerSender sender = new CustomerSender(_service);
            var response = await sender.Update(_mapper.Map<Customer>(request));
            return Ok(response);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> delete(CustomerRequest request)
        {
            CustomerSender sender = new CustomerSender(_service);
            var response = await sender.Delete(_mapper.Map<Customer>(request));
            return Ok(response);
        }

        [HttpGet("getbyemail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> getbyemail(string email)
        {
            CustomerSender sender = new CustomerSender(_service);
            var response = await sender.GetByEmail(email);
            return Ok(response);
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> getall()
        {
            CustomerSender sender = new CustomerSender(_service);
            var response = await sender.GetAll();
            return Ok(response);
        }
    }
}
