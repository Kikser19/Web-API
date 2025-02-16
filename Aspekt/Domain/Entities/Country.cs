using System.ComponentModel.DataAnnotations;

namespace Aspekt.Domain.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
