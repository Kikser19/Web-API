using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Country_Response
{
    public class CountryGetAllResponse
    {
        public List<Country> countries { get; set; }

        public CountryGetAllResponse(List<Country> countries)
        {
            this.countries = countries;
        }
    }
}
