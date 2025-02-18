using Aspekt.Application.Command.Country_Commands;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Country_Handlers
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Unit>
    {
        public readonly ICountryService _countryService;

        public DeleteCountryHandler(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }
        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
