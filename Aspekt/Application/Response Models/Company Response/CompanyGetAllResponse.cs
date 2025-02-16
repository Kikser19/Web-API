using Aspekt.Domain.Entities;

namespace Aspekt.Application.Response_Models.Company_Response
{
    public class CompanyGetAllResponse
    {
        public List<Company> Companies { get; set; }

        public CompanyGetAllResponse(List<Company> Companies)
        {
            this.Companies = Companies;
        }
    }
}
