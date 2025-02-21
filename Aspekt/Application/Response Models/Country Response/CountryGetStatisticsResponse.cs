namespace Aspekt.Application.Response_Models.Country_Response
{
    public class CountryGetStatisticsResponse
    {
        public Dictionary<string, int> dictionary { get; set; }

        public CountryGetStatisticsResponse(Dictionary<string, int> dictionary)
        {
            this.dictionary = dictionary;
        }
    }
}
