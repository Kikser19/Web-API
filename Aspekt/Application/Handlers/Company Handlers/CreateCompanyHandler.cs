using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aspekt.Application.Handlers.Company_Handlers
{
   
    public class CreateCompanyHandler : IRequestHandler<AddCompanyCommand, CompanyCreateResponse>
    {
        private readonly ICompanyService companyService;
        //private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyService companyService)
        {
            this.companyService = companyService;
            //_mapper = mapper;
        }


        public async Task<CompanyCreateResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(request.Company.CompanyName);
            return await companyService.Create(company);
        }
    }
}
