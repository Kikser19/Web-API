using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Queries.Company;
using Aspekt.Application.Queries.Country;
using Aspekt.Application.Request_Models.Company_Request;
using Aspekt.Application.Request_Models.Country_Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet("getCountries")]
        public async Task<IActionResult> getAllCountries()
        {
            var results = await _mediator.Send(new CountryGetAllQuery { }, default);
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
    }
}
