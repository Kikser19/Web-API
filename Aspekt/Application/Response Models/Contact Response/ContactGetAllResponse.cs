using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactGetAllResponse
    {
        public List<Contact> contacts {  get; set; }

        public ContactGetAllResponse(List<Contact> contacts)
        {
            this.contacts = contacts;
        }
    }
}
