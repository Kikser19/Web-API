using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Infrastructure.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CompanyRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;

        }
        public async Task<List<Company>> GetAll()
        {
            var result = await _applicationDbContext.Companies.ToListAsync();
            return result;
        }
        public async Task<CompanyCreateResponse> Create(Company company)
        {
            _applicationDbContext.Companies.Add(company);
            await _applicationDbContext.SaveChangesAsync(); // This is already async

            return new CompanyCreateResponse(company); // Directly return the response
        }


    }
}
