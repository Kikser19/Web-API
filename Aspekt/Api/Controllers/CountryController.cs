using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Queries.Country;
using Aspekt.Application.Request_Models.Country_Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IMediator _mediator, ILogger<CountryController> _logger)
        {
            this._mediator = _mediator;
            this._logger = _logger;
        }

        [HttpGet("getCountries")]
        public async Task<IActionResult> getAllCountries()
        {
            _logger.LogInformation("Fetching all countries...");
            try
            {
                var results = await _mediator.Send(new CountryGetAllQuery(), default);
                _logger.LogInformation("Successfully loaded countries.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching countries.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("/country/{id}")]
        public async Task<ActionResult<CountryGetByIdQuery>> GetById(int id)
        {
            _logger.LogInformation("Fetching country with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new CountryGetByIdQuery { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Country with ID: {Id} not found.", id);
                    return NotFound($"Country with ID {id} not found.");
                }
                _logger.LogInformation("Successfully retrieved country with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching country with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("createCountry")]
        public async Task<IActionResult> createCountry(CreateCountryRequest newCountry)
        {
            _logger.LogInformation("Creating a new country");
            try
            {
                var result = await _mediator.Send(new CreateCountryCommand { Country = newCountry }, default);
                _logger.LogInformation("Successfully created country");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating country");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("country/{id}")]
        public async Task<IActionResult> deleteCountry(int id)
        {
            _logger.LogInformation("Deleting country with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new DeleteCountryCommand { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Country with ID: {Id} not found.", id);
                    return NotFound($"Country with ID {id} not found.");
                }
                _logger.LogInformation("Successfully deleted country with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting country with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCountry(UpdateCountryRequest countryRequest, [FromRoute] int id)
        {
            _logger.LogInformation("Updating country with ID: {Id}", id);
            try
            {
                countryRequest.Id = id;
                var result = await _mediator.Send(new UpdateCountryCommand { Country = countryRequest }, default);
                if (result == null)
                {
                    _logger.LogWarning("Country with ID: {Id} not found.", id);
                    return NotFound($"Country with ID {id} not found.");
                }
                _logger.LogInformation("Successfully updated country with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating country with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getCompanyStatistics")]
        public async Task<IActionResult> GetCompanyStatisticsByCountryId(int countryId)
        {
            _logger.LogInformation("Fetching company statistics for country ID: {CountryId}", countryId);
            try
            {
                var results = await _mediator.Send(new CountryGetStatisticsQuery { countryId = countryId }, default);
                _logger.LogInformation("Successfully retrieved company statistics for country ID: {CountryId}", countryId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching company statistics for country ID: {CountryId}", countryId);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
