using Aspekt.Application.Request_Models.Company_Request;
using Aspekt.Application.Response_Models.Company_Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Command.Company_Commands
{
    public class UpdateCompanyCommand : IRequest<CompanyUpdateResponse>
    {
        [Required]
        public UpdateCompanyRequest Company { get; set; }
    }
}
