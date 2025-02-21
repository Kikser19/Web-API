using Aspekt.Application.Queries.Country;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class CountryGetStatistics : IRequestHandler<CountryGetStatisticsQuery, CountryGetStatisticsResponse>
    {
        private readonly ICountryService _countryService;

        public CountryGetStatistics(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }

        public async Task<CountryGetStatisticsResponse> Handle(CountryGetStatisticsQuery request, CancellationToken cancellationToken)
        {
            Dictionary<string, int> dictionary = await _countryService.GetCompanyStatisticsByCountryId(request.countryId);
            return new CountryGetStatisticsResponse(dictionary);
        }
    }
}
