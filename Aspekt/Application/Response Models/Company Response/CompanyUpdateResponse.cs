using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Company_Response
{
    public class CompanyUpdateResponse
    {
        public Company company { get; set; }

        public CompanyUpdateResponse(Company company)
        {
            this.company = company;
        }
    }
}
