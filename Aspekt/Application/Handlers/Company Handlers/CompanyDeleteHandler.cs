using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Queries.Company;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Implementation;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Company_Handlers
{
    public class CompanyDeleteHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly ICompanyService _companyService;

        public CompanyDeleteHandler(ICompanyService _companyService)
        {
            this._companyService = _companyService;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
