using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactGetByIdResponse
    {
        public Contact contact { get; set; }

        public ContactGetByIdResponse(Contact contact)
        {
            this.contact = contact;
        }
    }
}
