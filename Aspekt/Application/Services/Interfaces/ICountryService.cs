using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Application.Services.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<CountryCreateResponse> Create(Country country);
        Task Delete(int id);
        Task<Country> Update(Country country);
    }
}
