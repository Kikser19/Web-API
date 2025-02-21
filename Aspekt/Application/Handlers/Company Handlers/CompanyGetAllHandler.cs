using Aspekt.Application.Queries.Company;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using MediatR;

namespace Aspekt.Application.Handlers.Company_Handlers
{
    public class CompanyGetAllHandlers : IRequestHandler<CompanyGetAllQuerry, CompanyGetAllResponse>
    {
        private readonly ICompanyService _companyService;

        public CompanyGetAllHandlers(ICompanyService _companyService)
        {
            this._companyService = _companyService;
        }
        public async Task<CompanyGetAllResponse> Handle(CompanyGetAllQuerry request, CancellationToken cancellationToken)
        {
            var companies = await _companyService.GetAll(request.PageNumber, request.PageSize);
            return new CompanyGetAllResponse(companies);
        }
    }
}
