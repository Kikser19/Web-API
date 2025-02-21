using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Command.Contact_Commans;
using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Queries.Contact;
using Aspekt.Application.Queries.Country;
using Aspekt.Application.Request_Models.Company_Request;
using Aspekt.Application.Request_Models.Contact_Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet("getContacts")]
        public async Task<IActionResult> getAllContacts()
        {
            var results = await _mediator.Send(new ContactGetAllQuery { }, default);
            return Ok(results);
        }
        [HttpGet("/contact/{id}")]
        public async Task<ActionResult<ContactGetByIdQuery>> GetById(int id)
        {
            Console.WriteLine("vleze");
            var result = await _mediator.Send(new ContactGetByIdQuery { Id = id }, default);
            return Ok(result);
        }

        [HttpDelete("contact/{id}")]
        public async Task<IActionResult> deleteContact(int id)
        {
            var result = await _mediator.Send(new DeleteContactCommand { Id = id }, default);
            return Ok(result);
        }

        [HttpPost("createContact")]
        public async Task<IActionResult> createContact(CreateContactRequest newContact)
        {
            var results = await _mediator.Send(new CreateContactCommand { Conatct = newContact }, default);
            return Ok(results);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> updateContact(UpdateContactRequest contactRequest, [FromRoute] int id)
        {
            contactRequest.Id = id;
            var result = await _mediator.Send(new UpdateContactCommand { Contact = contactRequest }, default);
            return Ok(result);
        }

        [HttpGet("ContactWithCompanyAndCountry")]
        public async Task<IActionResult> getAllContactWithCompanyAndCountryDTO()
        {
            var results = await _mediator.Send(new ContactWithCompanyAndCountryQuery { }, default);
            return Ok(results);
        }

        [HttpGet("FilterContacts")]
        public async Task<IActionResult> filterContacts(int? companyId, int? countryid)
        {
            var results = await _mediator.Send(new ContactFilterQuery { CompanyId = companyId, CountryId = countryid }, default);
            return Ok(results);
        }
    }
}
