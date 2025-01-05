using Ardalis.GuardClauses;
using Notify.Application.Orders.CustomerOrder.Commands;
using Notify.Application.Orders.CustomerOrder.Queries;
using Notify.Contracts;
using Notify.Contracts.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Notify.API.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = Guard.Against.Null(sender, nameof(sender));


        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="request">The request containing customer details.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A newly created customer ID.</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
        public async Task<IActionResult> AddCustomer(
            [FromBody] CustomerCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            var customerId = await _sender.Send(new CreateCustomerCommand(request.CustomerName), cancellationToken);
            return Created($"api/v1/customers", customerId);
        }


        /// <summary>
        /// Retrieves the details of a specified customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The details of the specified customer.</returns>
        [Route("{customerId:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            var customerDetails = await _sender.Send(new GetCustomerQuery(customerId));
            return Ok(customerDetails);
        }
    }
}
