using Aspekt.Application.Request_Models.Contact_Request;
using Aspekt.Application.Request_Models.Country_Request;
using Aspekt.Application.Response_Models.Contact_Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Command.Contact_Commans
{
    public class CreateContactCommand : IRequest<ContactCreateResponse>
    {
        [Required]
        public CreateContactRequest Conatct { get; set; }
    }
}
