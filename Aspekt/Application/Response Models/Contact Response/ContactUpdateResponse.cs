using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactUpdateResponse
    {
        public Contact contact { get; set; }

        public ContactUpdateResponse(Contact contact) 
        { 
            this.contact = contact;
        }
    }
}
