using Aspekt.Application.Queries.Contact;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class ContactWithCompanyAndCountryHandler : IRequestHandler<ContactWithCompanyAndCountryQuery, ContactWithCompanyAndCountryResponse>
    {
        private readonly IContactService _contactService;

        public ContactWithCompanyAndCountryHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<ContactWithCompanyAndCountryResponse> Handle(ContactWithCompanyAndCountryQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetContactWithCompanyAndCountry();
            return new ContactWithCompanyAndCountryResponse(contacts);
        }
    }
}
