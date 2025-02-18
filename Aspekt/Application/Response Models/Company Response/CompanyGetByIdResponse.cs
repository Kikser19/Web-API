using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Company_Response
{
    public class CompanyGetByIdResponse
    {
        public Company company { get; set; }

        public CompanyGetByIdResponse(Company company)
        {
            this.company = company;
        }
    }
}
