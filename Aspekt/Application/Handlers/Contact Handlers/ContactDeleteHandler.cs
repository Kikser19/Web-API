using Aspekt.Application.Command.Contact_Commans;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class ContactDeleteHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactService _contactService;

        public ContactDeleteHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _contactService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
