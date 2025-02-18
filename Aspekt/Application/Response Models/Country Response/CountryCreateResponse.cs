using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Country_Response
{
    public class CountryCreateResponse
    {
        public Country country { get; set; }

        public CountryCreateResponse(Country country)
        {
            this.country = country;
        }
    }
}
