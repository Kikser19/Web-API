using Aspekt.Application.DTOs;
using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Contact_Response
{
    public class ContactWithCompanyAndCountryResponse
    {
        public List<ContactWithCompanyAndCountryDTO> contacts { get; set; }

        public ContactWithCompanyAndCountryResponse(List<ContactWithCompanyAndCountryDTO> contacts)
        {
            this.contacts = contacts;
        }
    }
}
