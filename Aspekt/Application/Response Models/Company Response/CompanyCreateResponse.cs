using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Company_Response
{
    public class CompanyCreateResponse
    {
        public Company Company { get; set; }

        public CompanyCreateResponse(Company company)
        {
            this.Company = company;
        }
    }
}
