using Aspekt.Application.Queries.Company;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Company_Handlers
{
    public class CompanyGetByIdHandler : IRequestHandler<CompanyGetByIdQuery, CompanyGetByIdResponse>
    {
        private readonly ICompanyService _companyService;
        //private readonly IMapper _mapper;

        public CompanyGetByIdHandler(ICompanyService _companyService)
        {
            this._companyService = _companyService;
            //_mapper = mapper;
        }
        public async Task<CompanyGetByIdResponse> Handle(CompanyGetByIdQuery request, CancellationToken cancellationToken)
        {
            var getCompanyById = await _companyService.GetById(request.Id);

            return new CompanyGetByIdResponse(getCompanyById);

        }
    }
}
