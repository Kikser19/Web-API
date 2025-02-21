using Aspekt.Application.Response_Models.Contact_Response;
using MediatR;

namespace Aspekt.Application.Queries.Contact
{
    public class ContactWithCompanyAndCountryQuery : IRequest<ContactWithCompanyAndCountryResponse>
    {
    }
}
