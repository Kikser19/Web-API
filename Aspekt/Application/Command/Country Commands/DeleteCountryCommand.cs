using Aspekt.Application.Response_Models.Country_Response;
using MediatR;

namespace Aspekt.Application.Command.Country_Commands
{
    public class DeleteCountryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
