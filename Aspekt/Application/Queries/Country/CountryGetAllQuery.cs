using Aspekt.Application.Response_Models.Country_Response;
using MediatR;

namespace Aspekt.Application.Queries.Country
{
    public class CountryGetAllQuery : IRequest<CountryGetAllResponse>
    {
    }
}
