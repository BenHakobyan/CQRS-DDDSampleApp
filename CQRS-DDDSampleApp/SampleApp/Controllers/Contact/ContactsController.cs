using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Application.Commands.Contact;
using SampleApp.Application.DTO;
using SampleApp.Application.Queries.Contact;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SampleApp.Controllers.Contact
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get contacts list.
        /// </summary>
        /// <returns>List of contacts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ContactDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetContactsList()
        {
            var contacts = await _mediator.Send(new GetContactListQuery());

            return Ok(contacts);
        }

        /// <summary>
        /// Get contact by ID.
        /// </summary>
        /// <param name="contactId">Contact ID.</param>
        [Route("{contactId}")]
        [HttpGet]
        [ProducesResponseType(typeof(ContactDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrderDetails([FromRoute]int contactId)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery(contactId));

            return Ok(contact);
        }

        /// <summary>
        /// Add contact.
        /// </summary>
        /// <param name="request">Contact model.</param>
        /// <returns>ID of created contact</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder([FromBody]CreateContactRequest request)
        {
            var id = await _mediator.Send(new AddContactCommand(request.FullName, request.Email, request.PhoneNumber, request.Address));

            return Created(string.Empty, id);
        }

        /// <summary>
        /// Change contact.
        /// </summary>
        /// <param name="contactId">Customer ID.</param>
        /// <param name="request">ContactModel</param>
        [Route("{contactId}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeCustomerOrder([FromRoute]int contactId, [FromBody]ContactDTO request)
        {
            request.Id = contactId;

            await _mediator.Send(new EditContactCommand(request));

            return Ok();
        }

        /// <summary>
        /// Remove contact by ID.
        /// </summary>
        /// <param name="contactId">Contact ID.</param>
        [Route("{contactId}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveCustomerOrder([FromRoute]int contactId)
        {
            await _mediator.Send(new DeleteContactCommand(contactId));

            return Ok();
        }
    }
}
