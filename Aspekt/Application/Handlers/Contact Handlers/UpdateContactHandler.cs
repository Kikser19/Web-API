using Aspekt.Application.Command.Company_Commands;
using Aspekt.Application.Command.Contact_Commans;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Implementation;
using Aspekt.Application.Services.Interfaces;
using MediatR;

namespace Aspekt.Application.Handlers.Contact_Handlers
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, ContactUpdateResponse>
    {
        private readonly IContactService _contactService;

        public UpdateContactHandler(IContactService _contactService)
        {
            this._contactService = _contactService;
        }
        public async Task<ContactUpdateResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var oldContact = await _contactService.GetById(request.Contact.Id);
            oldContact.CountryId = request.Contact.CountryId;
            oldContact.CompanyId = request.Contact.CompanyId;  
            oldContact.ContactName = request.Contact.ContactName;
            await _contactService.Update(oldContact);
            return new ContactUpdateResponse(oldContact);
        }
    }
}
