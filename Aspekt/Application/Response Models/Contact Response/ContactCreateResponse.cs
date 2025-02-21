using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactCreateResponse
    {
        public Contact contact { get; set; }

        public ContactCreateResponse(Contact contact)
        {
            this.contact = contact;
        }
    }
}
