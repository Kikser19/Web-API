using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure;
using Aspekt.Infrastructure.Interfaces;
using System.Diagnostics;

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
            return await _companyRepository.Create(company);
        }

        public async Task Delete(int id)
        {
            var company = await this.GetById(id);
            await _companyRepository.Delete(company);
        }

        public async Task<List<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetById(id);
        }

        public async Task<Company> Update(Company company)
        {
            return await _companyRepository.Update(company);
        }
    }
}
