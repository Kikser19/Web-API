using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Infrastructure.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAll();

        Task<CompanyCreateResponse> Create(Company company);
    }
}
