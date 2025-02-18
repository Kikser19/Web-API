using Aspekt.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Request_Models.Company_Request
{
    public class UpdateCompanyRequest
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }
        public List<Contact>? Contacts { get; set; }
    }
}
