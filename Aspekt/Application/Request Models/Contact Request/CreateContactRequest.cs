namespace Aspekt.Application.Request_Models.Contact_Request
{
    public class CreateContactRequest
    {
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
