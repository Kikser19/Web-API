using Aspekt.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Request_Models.Country_Request
{
    public class UpdateCountryRequest
    {
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
