using Aspekt.Application.Response_Models.Company_Response;
using MediatR;

namespace Aspekt.Application.Queries.Company
{
    public class CompanyGetAllQuerry : IRequest<CompanyGetAllResponse>
    {
    }
}
