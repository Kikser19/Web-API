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
            var results = await _mediator.Send(new CountryGetAllQuery { }, default);
            _logger.LogInformation("Successfully loadad countries.");
            return Ok(results);
        }

        [HttpGet("/country/{id}")]
        public async Task<ActionResult<CountryGetByIdQuery>> GetById(int id)
        {
            Console.WriteLine("vleze");
            var result = await _mediator.Send(new CountryGetByIdQuery { Id = id }, default);
            return Ok(result);
        }

        [HttpPost("createCountry")]
        public async Task<IActionResult> createCountry(CreateCountryRequest newCountry)
        {
            var results = await _mediator.Send(new CreateCountryCommand { Country = newCountry }, default);
            return Ok(results);
        }

        [HttpDelete("country/{id}")]
        public async Task<IActionResult> deleteCountry(int id)
        {
            var result = await _mediator.Send(new DeleteCountryCommand { Id = id }, default);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCountry(UpdateCountryRequest countryRequest, [FromRoute] int id)
        {
            countryRequest.Id = id;
            var result = await _mediator.Send(new UpdateCountryCommand { Country = countryRequest }, default);
            return Ok(result);
        }
        [HttpGet("getCompanyStatistics")]
        public async Task<IActionResult> GetCompanyStatisticsByCountryId(int countryId)
        {
            var results = await _mediator.Send(new CountryGetStatisticsQuery { countryId = countryId }, default);
            return Ok(results);
        }
    }
}
