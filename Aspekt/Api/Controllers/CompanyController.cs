using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Queries.Company;
using Aspekt.Application.Request_Models.Company_Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController ( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getCompanies")]
        public async Task<IActionResult> getAllCompanies()
        {
            var results = await _mediator.Send(new CompanyGetAllQuerry { }, default);
            return Ok(results);
        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> createCompany(CreateCompanyRequest newCompany)
        {
            var results = await _mediator.Send(new AddCompanyCommand { Company = newCompany }, default);
            return Ok(results);
        }

    }
}
