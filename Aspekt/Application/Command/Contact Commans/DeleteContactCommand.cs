using MediatR;

namespace Aspekt.Application.Command.Contact_Commans
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
