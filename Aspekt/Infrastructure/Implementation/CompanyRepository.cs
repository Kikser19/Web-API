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
        public async Task<List<Company>> GetAll(int? PageNumber = 1, int? PageSize = 10)
        {
            PageNumber = PageNumber ?? 1;
            PageSize = PageSize ?? 10;

            return await _applicationDbContext.Companies
                                .Include(c => c.Contacts)
                                .Skip((PageNumber.Value - 1) * PageSize.Value)
                                .Take(PageSize.Value)                         
                                .ToListAsync();
        }
        public async Task<CompanyCreateResponse> Create(Company company)
        {
            _applicationDbContext.Companies.Add(company);
            await _applicationDbContext.SaveChangesAsync();

            return new CompanyCreateResponse(company);
        }

        public async Task<Company> GetById(int id)
        {
            return await _applicationDbContext.Set<Company>().FindAsync(id);
        }

        public async Task Delete(Company company)
        {
            _applicationDbContext.Set<Company>().Remove(company);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Company> Update(Company company)
        {
            _applicationDbContext.Update(company);
            await _applicationDbContext.SaveChangesAsync();
            return company;
        }
    }
}
