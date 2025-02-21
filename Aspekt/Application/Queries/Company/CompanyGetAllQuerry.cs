using Aspekt.Application.Response_Models.Company_Response;
using MediatR;

namespace Aspekt.Application.Queries.Company
{
    public class CompanyGetAllQuerry : IRequest<CompanyGetAllResponse>
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
}
