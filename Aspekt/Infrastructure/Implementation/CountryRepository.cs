using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Infrastructure.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CountryRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }

        public async Task<CountryCreateResponse> Create(Country country)
        {
            _applicationDbContext.Countries.Add(country);
            await _applicationDbContext.SaveChangesAsync();
            return new CountryCreateResponse(country);
        }

        public async Task Delete(Country country)
        {
            _applicationDbContext.Remove(country);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _applicationDbContext.Countries.Include(c => c.Contacts).ToListAsync();  
        }

        public async Task<Country> GetById(int id)
        {
            return await _applicationDbContext.Countries.FindAsync(id);
        }

        public async Task<Dictionary<string, int>> GetCompanyStatisticsByCountryId(int countryId)
        {
            var companyStats = await _applicationDbContext.Contacts
                .Where(c => c.CountryId == countryId) 
                .GroupBy(c => c.CompanyId)
                .Select(g => new
                {
                    CompanyId = g.Key,
                    ContactCount = g.Count()
                })
                .Join(_applicationDbContext.Companies,
                      stats => stats.CompanyId,
                      co => co.CompanyId,
                      (stats, co) => new
                      {
                          CompanyName = co.CompanyName,
                          ContactCount = stats.ContactCount
                      })
                .ToDictionaryAsync(x => x.CompanyName, x => x.ContactCount); 

            return companyStats;
        }


        public async Task<Country> Update(Country country)
        {
            _applicationDbContext.Update(country);
            await _applicationDbContext.SaveChangesAsync();
            return country;
        }
    }
}
