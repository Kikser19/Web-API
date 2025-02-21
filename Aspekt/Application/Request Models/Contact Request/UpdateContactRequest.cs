using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Request_Models.Contact_Request
{
    public class UpdateContactRequest
    {
        public int Id { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
