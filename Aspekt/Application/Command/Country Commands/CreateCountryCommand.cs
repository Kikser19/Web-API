using Aspekt.Application.Request_Models.Company_Request;
using Aspekt.Application.Request_Models.Country_Request;
using Aspekt.Application.Response_Models.Country_Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Aspekt.Application.Command.Country_Commands
{
    public class CreateCountryCommand : IRequest<CountryCreateResponse>
    {
        [Required]
        public CreateCountryRequest Country { get; set; }
    }
}
