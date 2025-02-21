using Aspekt.Application.Response_Models.Contact_Response;
using MediatR;

namespace Aspekt.Application.Queries.Contact
{
    public class ContactGetByIdQuery : IRequest<ContactGetByIdResponse>
    {
        public int Id { get; set; }
    }
}
