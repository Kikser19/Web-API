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
            var results = await _mediator.Send(new CreateCompanyCommand { Company = newCompany }, default);
            return Ok(results);
        }

        [HttpDelete("/company/{id}")]
        public async Task<IActionResult> deleteCompany(int id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand { Id = id }, default);
            return Ok(result);
        }

        [HttpGet("/company/{id}")]
        public async Task<ActionResult<CompanyGetByIdQuery>> GetById(int id)
        {
            Console.WriteLine("vleze");
            var result = await _mediator.Send(new CompanyGetByIdQuery { Id = id }, default);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyRequest companyRequest, [FromRoute] int id)
        {
            companyRequest.Id = id;
            var result = await _mediator.Send(new UpdateCompanyCommand { Company = companyRequest }, default);
            return Ok(result);
        }
    }
}
