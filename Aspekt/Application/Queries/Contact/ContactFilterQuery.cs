using Aspekt.Application.Response_Models.Contact_Response;
using MediatR;

namespace Aspekt.Application.Queries.Contact
{
    public class ContactFilterQuery : IRequest<ContactFilterResponse>
    {
        public int? CompanyId { get; set; }
        public int? CountryId { get; set; }
    }
}
