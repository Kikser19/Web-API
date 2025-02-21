using Aspekt.Application.Command.Contact_Commans;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ContactCreateResponse>
    {
        private readonly IContactService _contactService;
        public CreateContactHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<ContactCreateResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact(request.Conatct.ContactName, request.Conatct.CompanyId, request.Conatct.CountryId);
            return await _contactService.Create(contact);
        }
    }
}
