using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactFilterResponse
    {
        public List<Contact> Contacts { get; set; }

        public ContactFilterResponse(List<Contact> contacts)
        {
            this.Contacts = contacts;
        }
    }
}
