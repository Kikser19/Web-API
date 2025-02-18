using Aspekt.Application.Queries.Country;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class CountryGetByIdHandler : IRequestHandler<CountryGetByIdQuery, CountryGetByIdResponse>
    {
        private readonly ICountryService _countryService;

        public CountryGetByIdHandler(ICountryService _countryService)
        {
            this._countryService = _countryService;  
        }
        public async Task<CountryGetByIdResponse> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var getCountryById  = await _countryService.GetById(request.Id);
            return new CountryGetByIdResponse(getCountryById);    
        }
    }
}
