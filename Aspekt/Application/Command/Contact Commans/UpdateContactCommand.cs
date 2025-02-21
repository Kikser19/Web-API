using Aspekt.Application.Request_Models.Contact_Request;
using Aspekt.Application.Response_Models.Contact_Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Command.Contact_Commans
{
    public class UpdateContactCommand : IRequest<ContactUpdateResponse>
    {
        [Required]
        public UpdateContactRequest Contact { get; set; }
    }
}
