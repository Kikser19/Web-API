using Aspekt.Application.Response_Models.Company_Response;
using MediatR;

namespace Aspekt.Application.Command.Company_Commands
{
    public class DeleteCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
