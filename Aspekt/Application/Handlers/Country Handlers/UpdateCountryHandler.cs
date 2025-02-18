using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Request_Models.Country_Request;
using Aspekt.Application.Response_Models.Country_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, CountryUpdateResponse>
    {
        private readonly ICountryService _countryService;

        public UpdateCountryHandler(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }
        public async Task<CountryUpdateResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var oldCountry = await _countryService.GetById(request.Country.Id);
            oldCountry.CountryName = request.Country.CountryName;
            oldCountry.Contacts = request.Country.Contacts;
            await _countryService.Update(oldCountry);
            return new CountryUpdateResponse(oldCountry);
        }
    }
}
