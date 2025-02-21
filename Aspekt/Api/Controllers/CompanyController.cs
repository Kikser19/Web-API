using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Queries.Company;
using Aspekt.Application.Request_Models.Company_Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CompanyController> _logger;


        public CompanyController ( IMediator mediator, ILogger<CompanyController> _logger)
        {
            this._mediator = mediator;
            this._logger = _logger;
        }

        [HttpGet("getCompanies")]
        public async Task<IActionResult> getAllCompanies(int? PageNumber, int? PageSize)
        {
            _logger.LogInformation("Fetching all companies. PageNumber: {PageNumber}, PageSize: {PageSize}", PageNumber, PageSize);
            try
            {
                var results = await _mediator.Send(new CompanyGetAllQuerry { PageNumber = PageNumber, PageSize = PageSize }, default);
                _logger.LogInformation("Successfully retrieved companies.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching companies.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("/company/{id}")]
        public async Task<ActionResult<CompanyGetByIdQuery>> GetById(int id)
        {
            _logger.LogInformation("Fetching company with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new CompanyGetByIdQuery { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Company with ID: {Id} not found.", id);
                    return NotFound($"Company with ID {id} not found.");
                }
                _logger.LogInformation("Successfully retrieved company with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching company with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> createCompany([FromBody] CreateCompanyRequest newCompany)
        {
            _logger.LogInformation("Creating a new company");
            try
            {
                var result = await _mediator.Send(new CreateCompanyCommand { Company = newCompany }, default);
                _logger.LogInformation("Successfully created company");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating company");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyRequest companyRequest, [FromRoute] int id)
        {
            _logger.LogInformation("Updating company with ID: {Id}", id);
            try
            {
                companyRequest.Id = id;
                var result = await _mediator.Send(new UpdateCompanyCommand { Company = companyRequest }, default);
                if (result == null)
                {
                    _logger.LogWarning("Company with ID: {Id} not found.", id);
                    return NotFound($"Company with ID {id} not found.");
                }
                _logger.LogInformation("Successfully updated company with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating company with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("/company/{id}")]
        public async Task<IActionResult> deleteCompany(int id)
        {
            _logger.LogInformation("Deleting company with ID: {Id}", id);
            try
            {
                var result = await _mediator.Send(new DeleteCompanyCommand { Id = id }, default);
                if (result == null)
                {
                    _logger.LogWarning("Company with ID: {Id} not found.", id);
                    return NotFound($"Company with ID {id} not found.");
                }
                _logger.LogInformation("Successfully deleted company with ID: {Id}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting company with ID: {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
