using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure.Interfaces;

namespace Aspekt.Application.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository _countryRepository)
        {
            this._countryRepository = _countryRepository;
        }

        public async Task<CountryCreateResponse> Create(Country country)
        {
            return await _countryRepository.Create(country);
        }

        public async Task Delete(int id)
        {
            var country = await this.GetById(id);
            await _countryRepository.Delete(country);
        }

        public async Task<List<Country>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<Country> GetById(int id)
        {
            return await _countryRepository.GetById(id);
        }

        public async Task<Country> Update(Country country)
        {
            return await _countryRepository.Update(country);
        }
    }
}
