using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Infrastructure.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<CountryCreateResponse> Create(Country country);
        Task Delete(Country country);
        Task<Country> Update(Country country);
        Task<Dictionary<string, int>> GetCompanyStatisticsByCountryId(int countryId);
    }
}
