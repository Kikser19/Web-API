using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aspekt.Application.Handlers.Company_Handlers
{
   
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyCreateResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyHandler(ICompanyService _companyService)
        {
            this._companyService = _companyService;
        }


        public async Task<CompanyCreateResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(request.Company.CompanyName);
            return await _companyService.Create(company);
        }
    }
}
