namespace Aspekt.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.Metrics;

    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string ContactName { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

}
