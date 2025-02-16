using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure;
using Aspekt.Infrastructure.Interfaces;

namespace Aspekt.Application.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository _companyRepository)
        {
            this._companyRepository = _companyRepository;
        }

        public async Task<CompanyCreateResponse> Create(Company company)
        {
            var result = await _companyRepository.Create(company);
            return result;
        }

        public async Task<List<Company>> GetAll()
        {
            var result = await _companyRepository.GetAll();
            return result;
        }
    }
}
