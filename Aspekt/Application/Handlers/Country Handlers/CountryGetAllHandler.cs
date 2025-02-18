using Aspekt.Application.Queries.Company;
using Aspekt.Application.Queries.Country;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class CountryGetAllHandler : IRequestHandler<CountryGetAllQuery, CountryGetAllResponse>
    {
        private readonly ICountryService _countryService;
        public CountryGetAllHandler(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }
        public async Task<CountryGetAllResponse> Handle(CountryGetAllQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryService.GetAll();
            return new CountryGetAllResponse(countries);
        }
    }
}
