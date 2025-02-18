using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Country_Response
{
    public class CountryGetByIdResponse
    {
        public Country country { get; set; }

        public CountryGetByIdResponse(Country country)
        {
            this.country = country;
        }
    }
}
