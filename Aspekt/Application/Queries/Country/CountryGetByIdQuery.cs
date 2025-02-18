using Aspekt.Application.Response_Models.Country_Response;
using MediatR;

namespace Aspekt.Application.Queries.Country
{
    public class CountryGetByIdQuery : IRequest<CountryGetByIdResponse>
    {
        public int Id { get; set; }
    }
}
