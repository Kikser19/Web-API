namespace Aspekt.Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public Company(String CompanyName)
        {
            this.CompanyName = CompanyName;
        }
    }

}
