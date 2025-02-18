using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CountryCreateResponse>
    {
        private readonly ICountryService _countryService;

        public CreateCountryHandler(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }
        public async Task<CountryCreateResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var newCountry = new Country(request.Country.CountryName);
            return await _countryService.Create(newCountry);
        }
    }
}
