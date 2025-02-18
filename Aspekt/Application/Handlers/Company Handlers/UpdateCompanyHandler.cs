using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Company_Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompanyUpdateResponse>
    {
        private readonly ICompanyService _companyService;
        //private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyService _companyService)
        {
            this._companyService = _companyService;
            //_mapper = mapper;
        }
        public async Task<CompanyUpdateResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var oldCompany = await _companyService.GetById(request.Company.Id);
            oldCompany.CompanyName = request.Company.CompanyName;
            oldCompany.Contacts = request.Company.Contacts;
            await _companyService.Update(oldCompany);
            return new CompanyUpdateResponse(oldCompany);
        }
    }
}
