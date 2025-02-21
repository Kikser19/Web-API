using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Domain.Entities;
using System.Diagnostics;

namespace Aspekt.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAll(int? PageNumber, int? PageSize);
        Task<CompanyCreateResponse> Create(Company company);
        Task<Company> GetById(int id);
        Task Delete(int id);
        Task<Company> Update(Company company);
    }
}
