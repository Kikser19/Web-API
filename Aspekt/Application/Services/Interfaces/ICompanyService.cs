using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAll();

        Task<CompanyCreateResponse> Create(Company company);
        
    }
}
