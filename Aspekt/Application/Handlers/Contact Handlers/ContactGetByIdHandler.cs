using Aspekt.Application.Queries.Contact;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class ContactGetByIdHandler : IRequestHandler<ContactGetByIdQuery, ContactGetByIdResponse>
    {
        private readonly IContactService _contactService;

        public ContactGetByIdHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<ContactGetByIdResponse> Handle(ContactGetByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetById(request.Id);
            return new ContactGetByIdResponse(contact);
        }
    }
}
