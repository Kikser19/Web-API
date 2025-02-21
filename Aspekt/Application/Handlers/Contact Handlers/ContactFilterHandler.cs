using Aspekt.Application.Queries.Contact;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class ContactFilterHandler : IRequestHandler<ContactFilterQuery, ContactFilterResponse>
    {
        private readonly IContactService _contactService;

        public ContactFilterHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }

        public async Task<ContactFilterResponse> Handle(ContactFilterQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactService.Filter(request.CompanyId, request.CountryId);
            return new ContactFilterResponse(contacts);
        }
    }

}
