using Aspekt.Application.Command.Contact_Commans;
using Aspekt.Application.Queries.Contact;
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
        private readonly ILogger<ContactController> _logger;


        public ContactController(IMediator _mediator, ILogger<ContactController> _logger)
        {
            this._mediator = _mediator;
            this._logger = _logger;
        }

        [HttpGet("getContacts")]
        public async Task<IActionResult> getAllContacts()
        {
            _logger.LogInformation("Fetching all contacts...");
            try
            {
                var results = await _mediator.Send(new ContactGetAllQuery(), default);
                _logger.LogInformation("Successfully loaded contacts.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching contacts.");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("/contact/{id}")]
        public async Task<ActionResult<ContactGetByIdQuery>> GetById(int id)
        {
            _logger.LogInformation("Fetching contact with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new ContactGetByIdQuery { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Contact with ID: {Id} not found.", id);
                    return NotFound($"Contact with ID {id} not found.");
                }
                _logger.LogInformation("Successfully retrieved contact with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching contact with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("contact/{id}")]
        public async Task<IActionResult> deleteContact(int id)
        {
            _logger.LogInformation("Deleting contact with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new DeleteContactCommand { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Contact with ID: {Id} not found.", id);
                    return NotFound($"Contact with ID {id} not found.");
                }
                _logger.LogInformation("Successfully deleted contact with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting contact with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("createContact")]
        public async Task<IActionResult> createContact(CreateContactRequest newContact)
        {
            _logger.LogInformation("Creating a new contact");
            try
            {
                var result = await _mediator.Send(new CreateContactCommand { Conatct = newContact }, default);
                _logger.LogInformation("Successfully created contact");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating contact");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> updateContact(UpdateContactRequest contactRequest, [FromRoute] int id)
        {
            _logger.LogInformation("Updating contact with ID: {Id}", id);
            try
            {
                contactRequest.Id = id;
                var result = await _mediator.Send(new UpdateContactCommand { Contact = contactRequest }, default);
                if (result == null)
                {
                    _logger.LogWarning("Contact with ID: {Id} not found.", id);
                    return NotFound($"Contact with ID {id} not found.");
                }
                _logger.LogInformation("Successfully updated contact with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating contact with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("ContactWithCompanyAndCountry")]
        public async Task<IActionResult> getAllContactWithCompanyAndCountryDTO()
        {
            _logger.LogInformation("Fetching all contacts with company and country information...");
            try
            {
                var results = await _mediator.Send(new ContactWithCompanyAndCountryQuery(), default);
                _logger.LogInformation("Successfully retrieved contacts with company and country data.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching contacts with company and country data.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("FilterContacts")]
        public async Task<IActionResult> filterContacts(int? companyId, int? countryId)
        {
            _logger.LogInformation("Filtering contacts by CompanyId: {CompanyId} and CountryId: {CountryId}", companyId, countryId);
            try
            {
                var results = await _mediator.Send(new ContactFilterQuery { CompanyId = companyId, CountryId = countryId }, default);
                _logger.LogInformation("Successfully retrieved filtered contacts.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering contacts.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
