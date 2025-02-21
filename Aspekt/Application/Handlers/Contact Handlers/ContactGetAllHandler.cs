using Aspekt.Application.Queries.Company;
using Aspekt.Application.Queries.Contact;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class ContactGetAllHandler : IRequestHandler<ContactGetAllQuery, ContactGetAllResponse>
    {
        private readonly IContactService _contactService;

        public ContactGetAllHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<ContactGetAllResponse> Handle(ContactGetAllQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetAll();
            return new ContactGetAllResponse(contacts);
        }
    }
}
