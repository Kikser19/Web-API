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
        public int CountryId { get; set; }
        public Contact(string contactName, int companyId, int countryId)
        {
            this.ContactName = contactName;
            this.CompanyId = companyId;
            this.CountryId = countryId;
        }

    }

}
