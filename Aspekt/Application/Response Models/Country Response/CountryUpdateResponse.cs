using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Country_Response
{
    public class CountryUpdateResponse
    {
        public Country country {  get; set; }

        public CountryUpdateResponse(Country country)
        {
            this.country = country;
        }
    }
}
